%function improved cfo with Af
clear;
matlabpool open local 4;
tic                %Use tic-toc to calcuate time to excute the code between tic and toc
AntennaNum=24;
NPropes=180;
Nd=2*AntennaNum;
Nt=200; %500;
G=2;
alpha=2;
beta=2;
frepinit=0.05;%0.05;
deltafrep=0.005;%0.005;
frep=frepinit;
deltat=1; 
shDS=50;
shDSratio=0.1;
%----------------------------Define and intialize array with zero------------------
maxdimension=zeros(1,Nd);
mindimension=zeros(1,Nd);
maxv=zeros(1,Nd);
R=zeros(NPropes,Nd,Nt);  %Position
A=zeros(NPropes,Nd,Nt);  %Acceleration
M=zeros(NPropes,Nt);     %Fitness
iterfitness=zeros(1,Nt);
bestpos=zeros(1,Nd);

%matlabpool open local 5;

for k=1:(Nd/2)
    maxdimension(k)=3;        
    maxdimension(k+Nd/2)=pi;   
    mindimension(k)=1;      
    mindimension(k+Nd/2)=-pi;  
    maxv(k)=(maxdimension(k)- mindimension(k))/4.0;
    maxv(k+Nd/2)=(maxdimension(k+Nd/2)-mindimension(k+Nd/2))/4.0;
end    

%----------------------------------------intialize probes uniform-------------------
NNN=NPropes/Nd;
Ratio=(maxdimension-mindimension)/(NNN-1);
pp=1;
for i=1:Nd
    n=0;
    for p=1:NNN
        R(pp,i,1)=mindimension(i)+n*Ratio(i);
        pp=pp+1;
        n=n+1;
    end
end
%----------------------------------------intialize probe random----------------------
% for P=1:NPropes
% R(P,:,1)=rand(size(maxdimension)).*(maxdimension-mindimension) + mindimension;
% end
%-----------------------------------------CFO----------------------------------------
%intialize fitness
%matlabpool open localconfig1 8;
%matlabpool open local 4;
%tic
%parfor P=1:NPropes
for P=drange(1,NPropes)
%for P=1:NPropes
        M(P,1)=Calculate_Fitness_AF(R(P,:,1));
end
[bestfitness,index]=max(M(:,1));
bestpos=R(index,:,1);
%time loop
%for j=1:Nt-1
for j=drange(1,Nt-1)
        iterfitness(j)=bestfitness;
         frep=frep+deltafrep;
         if(frep>=1)
              frep=deltafrep;
         end
        %update Accelaration
        Asum=0;
        newM=M(:,j);
        newR=R(:,:,j);
        newiterR=R(:,:,j+1);
        newiterM=M(:,j+1);
        newA=A(:,:,j);
        
        %parfor P=1:NPropes
        %for P=drange(1,NPropes)
         for P=1:NPropes
            
                Asum=0; 
                Asum=repmat(U(newM-newM(P)).*(newM-newM(P)).^alpha,1,Nd).*((newR-repmat(newR(P,:),NPropes,1))./L(newR,repmat(newR(P,:),NPropes,1)).^beta);  
                Asum(P)=0;
                Fsum=sum(Asum);
                newA(P,:)=G*Fsum;
                %update position
                newiterR(P,:)=newR(P,:)+0.5*newA(P,:)*deltat;
                cmp= newiterR(P,:)<mindimension;
                      newiterR(P,:)=(mindimension+frep.*(newR(P,:)-mindimension)).*cmp+newiterR(P,:).*(1-cmp);
                cmp=newiterR(P,:)>maxdimension;
                      newiterR(P,:)=(maxdimension-frep.*(maxdimension-newR(P,:))).*cmp+newiterR(P,:).*(1-cmp);
                %update fitness
                newiterM(P)=Calculate_Fitness_AF(newiterR(P,:)); 

%                 Asum=0; 
%                 Asum=repmat(U(M(:,j)-M(P,j)).*(M(:,j)-M(P,j)).^alpha,1,Nd).*((R(:,:,j)-repmat(R(P,:,j),NPropes,1))./L(R(:,:,j),repmat(R(P,:,j),NPropes,1)).^beta);  
%                 Asum(P)=0;
%                 Fsum=sum(Asum);
%                 A(P,:,j)=G*Fsum;
%                 %update position
%                 R(P,:,j+1)=R(P,:,j)+0.5*A(P,:,j)*deltat;
%                 cmp= R(P,:,j+1)<mindimension;
%                       R(P,:,j+1)=(mindimension+frep.*(R(P,:,j)-mindimension)).*cmp+R(P,:,j+1).*(1-cmp);
%                 cmp=R(P,:,j+1)>maxdimension;
%                       R(P,:,j+1)=(maxdimension-frep.*(maxdimension-R(P,:,j))).*cmp+R(P,:,j+1).*(1-cmp);
%                 %update fitness
%                
%                 M(P,j+1)=Calculate_Fitness_AF(R(P,:,j+1));
%                 if(M(P,j+1)> bestfitness)
%                     bestfitness=M(P,j+1);
%                     bestpos=R(P,:,j+1);
%                 end
              
        end
        
        M(:,j)=newM(:);
        R(:,:,j)=newR(:,:);
        R(:,:,j+1)=newiterR(:,:);
        M(:,j+1)= newiterM(:);
        A(:,:,j)=newA(:,:);
        
        [newfitness,index]=max(M(:,j+1));
        if(newfitness>bestfitness)
            bestfitness=newfitness;
            bestpos=R(index,:,j+1);
        end
        %shrink DS around best prope
        if(mod(j,shDS)==0)
            mindimension=mindimension+(bestpos-mindimension)*shDSratio;
            maxdimension=maxdimension-(maxdimension-bestpos)*shDSratio;
            if(shDS>5)
               shDS=shDS-5;
            end
            if(shDSratio<0.5)
                shDSratio=shDSratio+0.1;
            end
        end
end
radiation=zeros(1,360);
%parfor fay=1:360
%for fay=drange(1,360)
for fay=1:360
    radiation(fay)=Calculate_Fitness_AF_fay(bestpos,fay);
end

%Hill Climping
% bestpos=Hill_Climbing_AF(bestpos,maxdimension,mindimension,frep);
% bestfitness=Calculate_Fitness_AF(bestpos);
% iterfitness(Nt)=bestfitness;

%Nelder Mead
fn=@Calculate_Fitness_AFmin;
n=Nd;
start=bestpos;
reqmin=10^(-16);
step=ones(1,Nd);
konvge=5;
kcount=10000;
[ xmin, ynewlo, icount, numres, ifault ] = nelmin ( fn, n, start, reqmin, step, konvge, kcount );
FitnessAfterNelder=ynewlo*-1;

radiationNelderMead=zeros(1,360);
%parfor fay=1:360
for fay=1:360
%for fay=1:360
    radiationNelderMead(fay)=Calculate_Fitness_AF_fay(xmin,fay);
end
%Draw CFO Results
iter=1:Nt;
figure,plot(iter,iterfitness);
title('iteration of cfo');
xlabel('iteration');
ylabel('fitness');
fay=1:360;
figure,polar((pi/180)*fay,radiation,'--r');
title('radiation of cfo');

figure,polar((pi/180)*fay,radiationNelderMead,'--r');
title('radiation of cfo with NelderMead');

result=[iterfitness(Nt) bestpos];
t=toc;
matlabpool close;
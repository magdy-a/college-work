%------------------------------------PSO_with_CFO----------------------------------
clear;
matlabpool open local 4;
tic        %Use tic-toc to calcuate time to excute the code between tic and toc
AntennaNum=24;
NParticles=90; 
NPropes=180;
Nd=2*AntennaNum;
Nt=250; 
Nsaved=5;
Nsat=3;
G=2;
alpha=2;
beta=2;
frepinit=0.05;
deltafrep=0.005;
frep=frepinit;
deltat=1;
shDS=50;
shDSratio=0.1;
%-----------------------------Intialize PSO Data-----------------------------------
no_of_iterations=500;
wmax=0.9;
wmin=0.4;
c1max=2.5;
c1min=0.5;
c1=2;
c2max=2.5;
c2min=0.5;
c2=1.3;
c=c1+c2;
w=2.0/abs(2-c-sqrt(c*c-4*c));
itermax=0;
%----------------------------Define and intialize array with zero------------------
maxdimension=zeros(1,Nd);
mindimension=zeros(1,Nd);
R=zeros(NPropes,Nd,Nt);  %Position
V=zeros(NParticles,Nd);     %Velocity
A=zeros(NPropes,Nd,Nt);  %Acceleration
M=zeros(NPropes,Nt);     %Fitness
iterfitness=zeros(1,Nt);
bestpos=zeros(1,Nd);
minpos=zeros(1,Nd);
maxpos=zeros(1,Nd);
maxv=zeros(1,Nd);

for k=1:(Nd/2)
    maxdimension(k)=3;        
    maxdimension(k+Nd/2)=pi;  
    mindimension(k)=1;       
    mindimension(k+Nd/2)=-pi;  
    maxv(k)=(maxdimension(k)- mindimension(k))/4.0;
    maxv(k+Nd/2)=(maxdimension(k+Nd/2)-mindimension(k+Nd/2))/4.0;
end
%----------------------------------------intialize probes uniform-------------------
NNN=NParticles/Nd;
Ratio=(maxdimension-mindimension)/(NNN-1);
pp=1;
for i=1:Nd
    n=0;
    for p=1:NNN
        R(pp,i)=mindimension(i)+n*Ratio(i);
        pp=pp+1;
        n=n+1;
    end
end
%----------------------------------------intialize probe random----------------------
% for P=1:NParticles
% R(P,:,1)=rand(size(maxdimension)).*(maxdimension-mindimension) + mindimension;
% V(P,:)=rand(size(maxv)).*(maxv-(-1*maxv))+(-1*maxv);
% end
%-----------------------------------------PSO----------------------------------------
oldpfitness=zeros(1,NParticles);
pbest=zeros(NParticles,Nd);
[iterbest,pbest,oldpfitness,indx,gfitness]=calculate_pbest_obj_AF(R(:,:,1),pbest,oldpfitness); %calculate pbest(personalbest) and iterationbest partice
gbest=iterbest;
resultpso(1)=gfitness;
itermax=0.75*no_of_iterations;
for iteration_no=drange(2,no_of_iterations)
	w=wmax-((wmax-wmin)/itermax)*iteration_no;
	c1=c1max-((c1max-c1min)/itermax)*iteration_no;
	c2=c2min+((c2max-c2min)/itermax)*iteration_no;
    for Particle =1:NParticles
        rand1(Particle,:)=rand(size(maxdimension));
        rand2(Particle,:)=rand(size(maxdimension));
    end
    V=w*V-c1*rand1.*(R(1:NParticles,:,1)-iterbest)-c2*rand2.*(R(1:NParticles,:,1)-gbest);
    R(1:NParticles,:,1)=R(1:NParticles,:,1)+V;
    for P=1:NParticles      
       for i=1:Nd   
            if R(P,i,1)>maxdimension(i)
                R(P,i,1)=maxdimension(i);
            end
            if R(P,i,1)<mindimension(i)
                R(P,i,1)=mindimension(i);
            end 
            if abs(V(P,i))>maxv(i)
                if V(P,i)>0
                    V(P,i)=maxv(i);
                else
                    V(P,i)=-maxv(i);
                end
            end
       end
    end
    [iterbest,pbest,oldpfitness,indx,pfitness]=calculate_pbest_obj_AF(R(1:NParticles,:,1),pbest,oldpfitness);
    if pfitness>gfitness
        gbest=iterbest;
        gfitness=pfitness;
    end
    resultpso(iteration_no)=gfitness;
end
%-------------------------------------------Draw PSO Result----------------------------------------
iter=1:no_of_iterations;
figure,plot(iter,resultpso);
title('iteration of pso');
xlabel('iteration');
ylabel('fitness');

for fayy=1:360
    AFf(fayy)=Calculate_Fitness_AF_fay(gbest(1,:),fayy);  
end
fayy=0:1:359;
figure,polar((pi/180)*fayy,real(AFf),'--r');
title('radiation of pso');
%---------------------------------------------CFO---------------------------------------------------
%start with pbest in pso for each particle
% R(1:NParticles,:,1)=pbest;
% for P=NParticles+1:NPropes
% R(P,:,1)=rand(size(maxdimension)).*(maxdimension-mindimension) + mindimension;
% end
%intialize probes on axis and put best probe from pso in first probe of cfo
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
R(1,:,1)=gbest(1,:);
%intialize fitness
for P=1:NPropes
        M(P,1)=Calculate_Fitness_AF(R(P,:,1));
end
[bestfitness,index]=max(M(:,1));
bestpos=R(index,:,1);
%time loop
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
for fay=1:360
    radiation(fay)=Calculate_Fitness_AF_fay(bestpos,fay);  %caculate Array Factor(Fitness) 
end

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
for fay=1:360
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
title('radiation after cfo with NelderMead');

result=[iterfitness(Nt) bestpos];

t=toc;      %use tic-toc to calcuate time to excute the code between tic and toc
matlabpool close;
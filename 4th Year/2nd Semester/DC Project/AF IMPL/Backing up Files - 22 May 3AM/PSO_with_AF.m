%PSO with AF
clear;
tic        %Use tic-toc to calcuate time to excute the code between tic and toc
AntennaNum=24;
NParticles=90; 
Nd=2*AntennaNum;
%-----------------------------Intialize PSO Data-----------------------------------
no_of_iterations=1000;
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
%----------------------------Define and intialize array with zero------------------
maxdimension=zeros(1,Nd);
mindimension=zeros(1,Nd);
R=zeros(NParticles,Nd);     %Position
V=zeros(NParticles,Nd);     %Velocity
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
% NNN=NParticles/Nd;
% Ratio=(maxdimension-mindimension)/(NNN-1);
% pp=1;
% for i=1:Nd
%     n=0;
%     for p=1:NNN
%         R(pp,i)=mindimension(i)+n*Ratio(i);
%         pp=pp+1;
%         n=n+1;
%     end
% end
%----------------------------------------intialize probe random----------------------
for P=1:NParticles
R(P,:)=rand(size(maxdimension)).*(maxdimension-mindimension) + mindimension;
V(P,:)=rand(size(maxv)).*(maxv-(-1*maxv))+(-1*maxv);
end
%-----------------------------------------PSO------------------------------%----------
rand1 = zeros(NParticles,Nd);
rand2 = zeros(NParticles,Nd);
resultpso = zeros(no_of_iterations);

oldpfitness=zeros(1,NParticles);
pbest=zeros(NParticles,Nd);
[iterbest,pbest,oldpfitness,indx,gfitness]=calculate_pbest_obj_AF(R(:,:),pbest,oldpfitness); %calculate pbest(personalbest) and iterationbest partice
gbest=iterbest;
resultpso(1)=gfitness;
itermax=0.75*no_of_iterations;

for iteration_no=2:no_of_iterations
	w=wmax-((wmax-wmin)/itermax)*iteration_no;
	c1=c1max-((c1max-c1min)/itermax)*iteration_no;
	c2=c2min+((c2max-c2min)/itermax)*iteration_no;
    for Particle =1:NParticles
        rand1(Particle,:)=rand(size(maxdimension));
        rand2(Particle,:)=rand(size(maxdimension));
    end
    V=w*V-c1*rand1.*(R(1:NParticles,:)-iterbest)-c2*rand2.*(R(1:NParticles,:)-gbest);
    R(1:NParticles,:)=R(1:NParticles,:)+V;
   
    for P=1:NParticles 
       for i=1:Nd   
            if R(P,i)>maxdimension(i)
                R(P,i)=maxdimension(i);
            end
            if R(P,i)<mindimension(i)
                R(P,i)=mindimension(i);
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
    [iterbest,pbest,oldpfitness,indx,pfitness]=calculate_pbest_obj_AF(R(1:NParticles,:),pbest,oldpfitness);
    if pfitness>gfitness
        gbest=iterbest;
        gfitness=pfitness;
    end
    resultpso(iteration_no)=gfitness;
end

%Nelder Mead
fn=@Calculate_Fitness_AFmin;
n=Nd;
start=gbest(1,:);
reqmin=10^(-16);
step=ones(1,Nd);
konvge=5;
kcount=10000;
[ xmin, ynewlo, icount, numres, ifault ] = nelmin ( fn, n, start, reqmin, step, konvge, kcount );
FitnessAfterNelder=ynewlo*-1;

AFNelder = zeros(1,360);

for fayy=1:360
    AFNelder(fayy)=Calculate_Fitness_AF_fay(xmin,fayy);  
end
%-------------------------------------------Draw PSO Result----------------------------------------
iter=1:no_of_iterations;
figure,plot(iter,resultpso);
title('iteration of pso');
xlabel('iteration');
ylabel('fitness');

AFf = zeros(1,360);

for fayy=1:360
    AFf(fayy)=Calculate_Fitness_AF_fay(gbest(1,:),fayy);  
end
fayy=0:1:359;
figure,polar((pi/180)*fayy,real(AFf),'--r');
title('radiation of pso');

figure,polar((pi/180)*fayy,real(AFNelder),'--r');
title('radiation of pso with Nelder Mead');

t=toc;
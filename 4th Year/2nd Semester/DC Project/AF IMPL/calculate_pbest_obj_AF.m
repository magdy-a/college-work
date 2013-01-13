function [iterbest,pbest,oldpfitness,indx,bestfitness] = calculate_pbest_obj_AF(pos, pbest,oldpfitness)
%#codegen
coder.inline('never')

%calculate personal best , iterbest and bestfitness

% fay1=0;
% fay2=90;
% fay3=180;
% fay4=30;

gpufay1 = gpuArray(0);
gpufay2 = gpuArray(90);
gpufay3 = gpuArray(180);
gpufay4 = gpuArray(30);

%Duplicated Code
% n=200; %24                            %number of antenna element in the array
% no_of_particle=500; %90

gpun = gpuArray(200);
gpuno_of_particle = gpuArray(500);

% degreestep=360/n;
% wl=1;                            %wave length
% d=0.5;
% beta=(2*pi)/wl;                  %phase shift
% seta=90;                         %because we will work only on horizontal level (in 2d)so zaxis will be 90
% r1=(n*d*wl)/(2*pi);              %radius of the circle

gpudegreestep= gpuArray(360/n);
gpuwl= gpuArray(1);
gpud= gpuArray(0.5);
gpubeta= gpuArray((2*pi)/wl);
gpuseta= gpuArray(90);
gpur1= gpuArray((n*d*wl)/(2*pi));

I=pos(1:no_of_particle,1:n);
phase=pos(1:no_of_particle,n + 1:n * 2);

gpuI = gpuArray(pos(1:no_of_particle,1:n));
gpuphase = gpuArray(pos(1:no_of_particle,n + 1:n * 2));

%Initialize Postion Vector
postion = zeros(1,n);

%Set Initial Value
postion(1)=0;

% from 2 to n
for i=2:n
    postion(i)=postion(i-1)+degreestep;
end

%end of %Duplicated Code

temp=repmat(beta.*r1.*sind(seta).*cosd(fay1-postion),no_of_particle,1);
elements=I.*exp(1i.*(temp-phase));
AFfay1=sum(elements,2);                         %for all particles

temp=repmat(beta.*r1.*sind(seta).*cosd(fay2-postion),no_of_particle,1);
elements=I.*exp(1i.*(temp-phase));
AFfay2=sum(elements,2);                         %for all particles

temp=repmat(beta.*r1.*sind(seta).*cosd(fay3-postion),no_of_particle,1);
elements=I.*exp(1i.*(temp-phase));
AFfay3=sum(elements,2);                         %for all particles

temp=repmat(beta.*r1.*sind(seta).*cosd(fay4-postion),no_of_particle,1);
elements=I.*exp(1i.*(temp-phase));
AFfay4=sum(elements,2);                         %for all particles

fitness=abs(AFfay1)+abs(AFfay2)+abs(AFfay3)-abs(AFfay4);

[bestfitness,indx]=max(fitness);
iterbest=pos(indx,:);
iterbest=repmat(iterbest,no_of_particle,1);


%pbest = zeros(no_of_particle,2*n);
for P=1:no_of_particle %parfor
    if(fitness(P)>oldpfitness(P))
        pbest(P,:)=pos(P,:);
        oldpfitness(P)=fitness(P);
    end
    % oldpfitness(P)=fitness(P);
end
end
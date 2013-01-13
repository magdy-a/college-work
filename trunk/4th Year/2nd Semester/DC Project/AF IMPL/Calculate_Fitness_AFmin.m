function AF = Calculate_Fitness_AFmin(p)
%#codegen
coder.inline('never')

%Calculate fitness of specific particle

fay1=0;
fay2=90;
fay3=180;
fay4=30;

%Duplicated Code
n=200; %24          %number of antenna element in the array
degreestep=360/n;
wl=1;           %wave length
d=0.5;
beta=(2*pi)/wl;   %phase shift
seta=90;        %because we will work only on horizontal level (in 2d)so zaxis will be 90
r1=(n*d*wl)/(2*pi);   %radius of the circle

I=p(1:n);
phase=p(n+1:n*2);

%Initialize Postion Vector
postion = zeros(1,n);

%Set Initial Value
postion(1)=0;

% from 2 to n
for i=2:n
    postion(i)=postion(i-1)+degreestep;
end

%end of %Duplicated Code

elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay1-postion)-phase));
AF1=sum(elements);


elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay2-postion)-phase));
AF2=sum(elements);

elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay3-postion)-phase));
AF3=sum(elements);

elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay4-postion)-phase));
AF4=sum(elements);

AF=-1*(abs(AF1)+abs(AF2)+abs(AF3)-abs(AF4));
end
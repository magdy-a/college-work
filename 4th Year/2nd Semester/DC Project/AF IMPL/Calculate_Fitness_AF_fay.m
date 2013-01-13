function AF = Calculate_Fitness_AF_fay(p,fay)
%#codegen
coder.inline('never')

%calculate Fitness(Array Factor) at specific angle(fay)

%Duplicated Code
n=200; %24                %number of antenna element in the array
degreestep=360/n;
wl=1;                 %wave length
d=0.5;
beta=(2*pi)/wl;       %phase shift
seta=90;              %because we will work only on horizontal level (in 2d)so zaxis will be 90
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

elements=I.*exp(1i.*(beta.*r1.*sind(seta).*cosd(fay-postion)-phase));
AF1=sum(elements);
AF=abs(AF1);

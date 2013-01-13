%calculate Fitness(Array Factor) at specific angle(fay)
function AF=Calculate_Fitness_AF_fay(p,fay)
n=24;                 %number of antenna element in the array
degreestep=360/n;
wl=1;                 %wave length
d=0.5;

beta=(2*pi)/wl;       %phase shift
seta=90;              %because we will work only on horizontal level (in 2d)so zaxis will be 90
r1=(n*d*wl)/(2*pi);   %radius of the circle

I=p(1:24);
phase=p(25:48);

postion(1)=0;
for i=2:n
    postion(i)=postion(i-1)+degreestep;
end

elements=I.*exp(j.*(beta.*r1.*sind(seta).*cosd(fay-postion)-phase));
AF1=sum(elements);
AF=abs(AF1);

function Result=L(Rk,Rp)    %Calculate Distance between 2 particle position 
Nd=length(Rk(1,:));
v=(Rk-Rp).^2;
R=sqrt(sum(v,2));
S=R==0;
R=R+S;
Result=repmat(R,1,Nd);

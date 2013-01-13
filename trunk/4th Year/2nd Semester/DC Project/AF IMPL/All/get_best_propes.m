function Newpos=get_best_propes(pos,fitness,Nd,NParticles)
for p=1:NParticles
    [maxparticle_in_iters,I]=max(fitness);
    [value,iterindx]=max(maxparticle_in_iters);
    propeindx=I(iterindx);
    Newpos(p,:)=pos(propeindx,:,iterindx);
    fitness(propeindx,iterindx)= intmin('int64');
end

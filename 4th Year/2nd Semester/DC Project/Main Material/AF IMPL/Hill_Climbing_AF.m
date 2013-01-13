function Current=Hill_Climbing_AF(Intial_State,maxdimension,mindimension,frep)
Step=0.001;
Current=Intial_State;
Prev=Current-Step;
Next=Current+Step;

cmp= Prev<mindimension;
Prev=(mindimension+frep.*(Current-mindimension)).*cmp+Prev.*(1-cmp);
cmp=Prev>maxdimension;
Prev=(maxdimension-frep.*(maxdimension-Current)).*cmp+Prev.*(1-cmp);

cmp= Next<mindimension;
Next=(mindimension+frep.*(Current-mindimension)).*cmp+Next.*(1-cmp);
cmp=Next>maxdimension;
Next=(maxdimension-frep.*(maxdimension-Current)).*cmp+Next.*(1-cmp);

while ((Calculate_Fitness_AF(Current)<Calculate_Fitness_AF(Prev)) | (Calculate_Fitness_AF(Current)<Calculate_Fitness_AF(Next)))
    if(Calculate_Fitness_AF(Current)<Calculate_Fitness_AF(Next))
        Current=Next;%-(Step*0.1);
    end
    if(Calculate_Fitness_AF(Current)<Calculate_Fitness_AF(Prev))
        Current=Prev;%+(Step*0.1);
    end
    Prev=Current-Step;
    Next=Current+Step;
    
    cmp= Prev<mindimension;
    Prev=(mindimension+frep.*(Current-mindimension)).*cmp+Prev.*(1-cmp);
    cmp=Prev>maxdimension;
    Prev=(maxdimension-frep.*(maxdimension-Current)).*cmp+Prev.*(1-cmp);

    cmp= Next<mindimension;
    Next=(mindimension+frep.*(Current-mindimension)).*cmp+Next.*(1-cmp);
    cmp=Next>maxdimension;
    Next=(maxdimension-frep.*(maxdimension-Current)).*cmp+Next.*(1-cmp);

end

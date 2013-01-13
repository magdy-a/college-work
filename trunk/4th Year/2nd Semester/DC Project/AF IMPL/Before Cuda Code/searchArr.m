function Result = searchArr( arr )

Result = zeros(size(arr));

for i = 1 : 5
    
    if(arr(i) == 2.0)   
        Result(i) = 1;
    end
end

%figure,plot(Result,arr);

end
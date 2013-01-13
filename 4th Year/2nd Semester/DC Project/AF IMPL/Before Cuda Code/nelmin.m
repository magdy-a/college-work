function [ xmin, ynewlo, icount, numres, ifault ] = nelmin ( fn, n, start, reqmin, step, konvge, kcount )

%% NELMIN minimizes a function using the Nelder-Mead algorithm.
%
%  Discussion:
%
%    This routine seeks the minimum value of a user-specified function.
%
%    Simplex function minimisation procedure due to Nelder+Mead(1965),
%    as implemented by O'Neill(1971, Appl.Statist. 20, 338-45), with
%    subsequent comments by Chambers+Ertel(1974, 23, 250-1), Benyon(1976,
%    25, 97) and Hill(1978, 27, 380-2)
%
%    The function to be minimized must be defined by a function of
%    the form
%
%      function fn ( x, f )
%      real ( kind = 8 ) fn
%      real ( kind = 8 ) x(*)
%
%    and the name of this subroutine must be declared EXTERNAL in the
%    calling routine and passed as the argument FN.
%
%    This routine does not include a termination test using the
%    fitting of a quadratic surface.
%
%  Modified:
%
%    28 February 2008
%
%  Author:
%
%    FORTRAN77 version by R ONeill
%    MATLAB version by John Burkardt
%
%  Reference:
%
%    John Nelder, Roger Mead,
%    A simplex method for function minimization,
%    Computer Journal,
%    Volume 7, 1965, pages 308-313.
%
%    R ONeill,
%    Algorithm AS 47:
%    Function Minimization Using a Simplex Procedure,
%    Applied Statistics,
%    Volume 20, Number 3, 1971, pages 338-345.
%
%  Parameters:
%
%    Input, external FN, the name of the function which evaluates
%    the function to be minimized.
%
%    Input, integer N, the number of variables.
%
%    Input, real START(N).  On input, a starting point
%    for the iteration.  On output, this data may have been overwritten.
%
%    Input, real REQMIN, the terminating limit for the variance
%    of function values.
%
%    Input, real STEP(N), determines the size and shape of the
%    initial simplex.  The relative magnitudes of its elements should reflect
%    the units of the variables.
%
%    Input, integer KONVGE, the convergence check is carried out
%    every KONVGE iterations.
%
%    Input, integer KCOUNT, the maximum number of function
%    evaluations.
%
%    Output, real XMIN(N), the coordinates of the point which
%    is estimated to minimize the function.
%
%    Output, real YNEWLO, the minimum value of the function.
%
%    Output, integer ICOUNT, the number of function evaluations
%    used.
%
%    Output, integer NUMRES, the number of restarts.
%
%    Output, integer IFAULT, error indicator.
%    0, no errors detected.
%    1, REQMIN, N, or KONVGE has an illegal value.
%    2, iteration terminated because KCOUNT was exceeded without convergence.
%

%#codegen
coder.inline('never')

% Removed

%xmin = [];
%ynewlo = [];

% End of Removed

icount = 0;
numres = 0;

ccoeff = 0.5;
ecoeff = 2.0;
eps = 0.01;
rcoeff = 1.0;
%
%  Check the input parameters.
%
if ( reqmin <= 0.0 )
    ifault = 1;
    return
end

if ( n < 1 )
    ifault = 1;
    return
end

if ( konvge < 1 )
    ifault = 1;
    return
end

jcount = konvge;
dn = n;
nn = n + 1;
dnn = nn;
del = 1.0;
rq = reqmin * dn;
%
%  Initial or restarted loop.
%

while ( 1 )
    
    % Initialize p !!
    p = zeros(n,nn);

    % Initialize y !!
    y = zeros(1,nn);
    
    for i = 1 : n
        p(i,nn) = start(i);
    end

    y(nn) = fn ( start );
    
    icount = icount + 1;

    for j = 1 : n
        x = start(j);
        start(j) = start(j) + step(j) * del;
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        if(j<=n/2)
            if (start(j)>3)
                start(j)=3;
            else if(start(j)<1)
                    start(j)=1;
                end
            end
        else
            if(start(j)>pi)
                start(j)=pi;
            else if(start(j)<-pi)
                    start(j)=-pi;
                end
            end
        end
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        for i = 1 : n
            p(i,j) = start(i);
        end
        y(j) = fn ( start );
        icount = icount + 1;
        start(j) = x;
    end
    %
    %  The simplex construction is complete.
    %
    %  Find highest and lowest Y values.  YNEWLO = Y(IHI) indicates
    %  the vertex of the simplex to be replaced.
    %
    ylo = y(1);
    ilo = 1;

    for i = 2 : nn
        if ( y(i) < ylo )
            ylo = y(i);
            ilo = i;
        end
    end
    %
    %  Inner loop.
    %
    
    % Initialize xmin
    xmin = zeros(1,n);
    
    while ( 1 )

        if ( kcount <= icount )
            break
        end

        ynewlo = y(1);
        ihi = 1;

        for i = 2 : nn
            if ( ynewlo < y(i) )
                ynewlo = y(i);
                ihi = i;
            end
        end
        %
        %  Calculate PBAR, the centroid of the simplex vertices
        %  excepting the vertex with Y value YNEWLO.
        %
        
        % Initialize pbar !!
        pbar = zeros(1,n);
        
        for i = 1 : n
            z = 0.0;
            for j = 1 : nn
                z = z + p(i,j);
            end
            z = z - p(i,ihi);  %p(i,ihi)worst point to be replaced
            pbar(i) = z / dn;  %pbar centroid point=Mid point between point except the worst point

            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            if(i<=n/2)
                if (pbar(i)>3)
                    pbar(i)=3;
                else if(pbar(i)<1)
                        pbar(i)=1;
                    end
                end
            else
                if(pbar(i)>pi)
                    pbar(i)=pi;
                else if(pbar(i)<-pi)
                        pbar(i)=-pi;
                    end
                end
            end
            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        end
        %
        %  Reflection through the centroid.
        %
        
        % Initialize pstar !!
        pstar = zeros(1,n);
        
        for i = 1 : n
            pstar(i) = pbar(i) + rcoeff * ( pbar(i) - p(i,ihi) );

            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            if(i<=n/2)
                if (pstar(i)>3)
                    pstar(i)=3;
                else if(pstar(i)<1)
                        pstar(i)=1;
                    end
                end
            else
                if(pstar(i)>pi)
                    pstar(i)=pi;
                else if(pstar(i)<-pi)
                        pstar(i)=-pi;
                    end
                end
            end
            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        end
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        ystar = fn ( pstar );
        icount = icount + 1;
        %
        %  Successful reflection, so extension.
        %
        
        % Initialize p2star !!
        p2star = zeros(1,n);
        
        if ( ystar < ylo )

            for i = 1 : n
                p2star(i) = pbar(i) + ecoeff * ( pstar(i) - pbar(i) );

                %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                if(i<=n/2)
                    if (p2star(i)>3)
                        p2star(i)=3;
                    else if(p2star(i)<1)
                            p2star(i)=1;
                        end
                    end
                else
                    if(p2star(i)>pi)
                        p2star(i)=pi;
                    else if(p2star(i)<-pi)
                            p2star(i)=-pi;
                        end
                    end
                end
                %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            end
            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            y2star = fn ( p2star );
            icount = icount + 1;
            %
            %  Check extension.
            %
            if ( ystar < y2star )

                for i = 1 : n
                    p(i,ihi) = pstar(i);
                end

                y(ihi) = ystar;
                %
                %  Retain extension or contraction.
                %
            else

                for i = 1 : n
                    p(i,ihi) = p2star(i);  %p(i,ihi) worst point replaced
                end

                y(ihi) = y2star;         %y(ihi) fitness of worst point

            end
            %
            %  No extension.
            %
        else

            l = 0;
            for i = 1 : nn
                if ( ystar < y(i) )
                    l = l + 1;
                end
            end

            if ( 1 < l )

                for i = 1 : n
                    p(i,ihi) = pstar(i);
                end

                y(ihi) = ystar;
                %
                %  Contraction on the Y(IHI) side of the centroid.
                %
            elseif ( l == 0 )

                for i = 1 : n
                    p2star(i) = pbar(i) + ccoeff * ( p(i,ihi) - pbar(i) );

                    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                    if(i<=n/2)
                        if (p2star(i)>3)
                            p2star(i)=3;
                        else if(p2star(i)<1)
                                p2star(i)=1;
                            end
                        end
                    else
                        if(p2star(i)>pi)
                            p2star(i)=pi;
                        else if(p2star(i)<-pi)
                                p2star(i)=-pi;
                            end
                        end
                    end
                    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                end
                %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                y2star = fn ( p2star );
                icount = icount + 1;
                %
                %  Contract the whole simplex.
                %
                if ( y(ihi) < y2star )

                    for j = 1 : nn
                        for i = 1 : n
                            p(i,j) = ( p(i,j) + p(i,ilo) ) * 0.5;

                            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                            if(i<=n/2)
                                if (p(i,j)>3)
                                    p(i,j)=3;
                                else if(p(i,j)<1)
                                        p(i,j)=1;
                                    end
                                end
                            else
                                if(p(i,j)>pi)
                                    p(i,j)=pi;
                                else if(p(i,j)<-pi)
                                        p(i,j)=-pi;
                                    end
                                end
                            end
                            %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                            xmin(i) = p(i,j);
                        end
                        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%55
                        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                        y(j) = fn ( xmin );
                        icount = icount + 1;
                    end

                    ylo = y(1);
                    ilo = 1;

                    for i = 2 : nn
                        if ( y(i) < ylo )
                            ylo = y(i);
                            ilo = i;
                        end
                    end

                    continue
                    %
                    %  Retain contraction.
                    %
                else

                    for i = 1 : n
                        p(i,ihi) = p2star(i);
                    end
                    y(ihi) = y2star;

                end
                %
                %  Contraction on the reflection side of the centroid.
                %
            elseif ( l == 1 )

                for i = 1 : n
                    p2star(i) = pbar(i) + ccoeff * ( pstar(i) - pbar(i) );

                    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                    if(i<=n/2)
                        if (p2star(i)>3)
                            p2star(i)=3;
                        else if(p2star(i)<1)
                                p2star(i)=1;
                            end
                        end
                    else
                        if(p2star(i)>pi)
                            p2star(i)=pi;
                        else if(p2star(i)<-pi)
                                p2star(i)=-pi;
                            end
                        end
                    end
                    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                end
                %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                y2star = fn ( p2star );
                icount = icount + 1;
                %
                %  Retain reflection?
                %
                if ( y2star <= ystar )

                    for i = 1 : n
                        p(i,ihi) = p2star(i);
                    end
                    y(ihi) = y2star ;

                else

                    for i = 1 : n
                        p(i,ihi) = pstar(i);
                    end
                    y(ihi) = ystar;

                end

            end

        end
        %
        %  Check if YLO improved.
        %
        if ( y(ihi) < ylo )
            ylo = y(ihi);
            ilo = ihi;
        end

        jcount = jcount - 1;

        if ( 0 < jcount )
            continue
        end
        %
        %  Check to see if minimum reached.
        %
        if ( icount <= kcount )

            jcount = konvge;

            z = 0.0;
            for i = 1 : nn
                z = z + y(i);
            end
            x = z / dnn;

            z = 0.0;
            for i = 1 : nn
                z = z + ( y(i) - x )^2;
            end

            if ( z <= rq )
                break
            end

        end

    end  %end of Inner Loop
    %
    %  Factorial tests to check that YNEWLO is a local minimum.
    %
    for i = 1 : n
        xmin(i) = p(i,ilo);
    end

    ynewlo = y(ilo);

    if ( kcount < icount )
        ifault = 2;
        break
    end

    ifault = 0;

    for i = 1 : n
        del = step(i) * eps;
        xmin(i) = xmin(i) + del;

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        if(i<=n/2)
            if (xmin(i)>3)
                xmin(i)=3;
            else if(xmin(i)<1)
                    xmin(i)=1;
                end
            end
        else
            if(xmin(i)>pi)
                xmin(i)=pi;
            else if(xmin(i)<-pi)
                    xmin(i)=-pi;
                end
            end
        end
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%55
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        z = fn ( xmin );
        icount = icount + 1;
        if ( z < ynewlo )
            ifault = 2;
            break
        end
        xmin(i) = xmin(i) - del - del;

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%my part to limit variable values%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        if(i<=n/2)
            if (xmin(i)>3)
                xmin(i)=3;
            else if(xmin(i)<1)
                    xmin(i)=1;
                end
            end
        else
            if(xmin(i)>pi)
                xmin(i)=pi;
            else if(xmin(i)<-pi)
                    xmin(i)=-pi;
                end
            end
        end
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%55
        %if   xmin(:)>500
        %     xmin(:)=500;
        %end;
        %if   xmin(:)<-500
        %    xmin(:)=-500;
        %end;
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        z = fn ( xmin );
        icount = icount + 1;
        if ( z < ynewlo )
            ifault = 2;
            break
        end
        xmin(i) = xmin(i) + del;
    end
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%55
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    if ( ifault == 0 )
        break
    end
    %
    %  Restart the procedure.
    %
    for i = 1 : n
        start(i) = xmin(i);
    end
    del = eps;
    numres = numres + 1;

end %end of outer loop



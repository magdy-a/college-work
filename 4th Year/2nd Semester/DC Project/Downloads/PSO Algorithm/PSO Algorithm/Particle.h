#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "SampleSpace.h"

SampleSpace Samplespace();

class Particle
{
private:
	int id;
	struct Velocity
{
	double X;
	double Y;
};
	struct Postion
{
	double X;
	double Y;
};
	Velocity ParticleVelocity;
	Postion  ParticlePostion;
	Postion Itrbest;
	Postion Gbest;
	int Maxrand;
	double c1;
	double c2;
	double w;
	double c;
public:
	Particle()
	{
		c1 = 2.5;
		c2 = 0.5;
		c = c1+c2;
		w = 2/abs(2-(c-sqrt((c*c)-(4*c))));
		ParticlePostion.X = RandomNumberGenerator().X;
		ParticlePostion.Y = RandomNumberGenerator().Y;
	}
	Postion RandomNumberGenerator()
	{
		Postion RandomPostion;
		RandomPostion.X = rand()%Maxrand;
		RandomPostion.Y = rand()%Maxrand;
		return RandomPostion;
	}
	Velocity CalculateVelocity (Postion CurrentPostion, Velocity CurrentVelocity)
	{
		Velocity NewVelocity;
		Postion gbestpostion = Multiple(c1,Multiple(rand(),Subtract(Gbest,CurrentPostion)));
		Postion itrpostion = Multiple(c2,Multiple(rand(),Subtract(Itrbest,CurrentPostion)));
		NewVelocity=Multiple(CurrentVelocity,Add(gbestpostion,itrpostion));
		return NewVelocity;
	}
	Postion CalculateNewPostion (Postion CurrentPostion)
	{
		Postion NewPostion;
		Velocity CurrentVelocity;
		NewPostion = Add(CurrentPostion,CurrentVelocity);
		return NewPostion;
	}
	Postion Add( Postion CurrentPostion, Velocity CurrentVelocity)
	{
		Postion NewPostion;
		NewPostion.X = CurrentPostion.X+CurrentVelocity.X;
		NewPostion.Y = CurrentPostion.Y+CurrentVelocity.Y;
		return NewPostion;
	}
	Postion Add( Postion CurrentPostion1, Postion CurrentVelocity2)
	{
		Postion AddedPostion;
		AddedPostion.X = CurrentPostion1.X+CurrentVelocity2.X;
		AddedPostion.Y = CurrentPostion1.Y+CurrentVelocity2.Y;
		return AddedPostion;
	}
	Postion Subtract(Postion CurrentPostion1, Postion CurrentPostion2)
	{
		Postion Subtractedpostion;
		Subtractedpostion.X = CurrentPostion1.X-CurrentPostion2.X;
		Subtractedpostion.Y = CurrentPostion1.Y-CurrentPostion2.Y;
		return Subtractedpostion;
	}
	Velocity Multiple (double w, Velocity CurrentVelocity)
	{
		Velocity MultipledVelocity;
		MultipledVelocity.X = CurrentVelocity.X*w;
		MultipledVelocity.Y = CurrentVelocity.Y*w;
		return MultipledVelocity;
	}
	Postion Multiple (double w, Postion CurrentPostion)
	{
		Postion MultipledPostion;
		MultipledPostion.X = CurrentPostion.X*w;
		MultipledPostion.Y = CurrentPostion.Y*w;
		return MultipledPostion;
	}
	Velocity Multiple (Velocity CurrentVelocity, Postion CurrentPostion)
	{
		Velocity MultipledVelocity;
		MultipledVelocity.X = CurrentPostion.X*CurrentVelocity.X;
		MultipledVelocity.Y = CurrentPostion.Y*CurrentVelocity.Y;
		return MultipledVelocity;
	}
};
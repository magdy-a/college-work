//#include "mpi.h"
//#include <iostream>
//
//using namespace std;
//
//const int master = 0;
//
//void main(int argc, char *argv[])
//{
//	int myId, numOfProcesses, value, valueToSearchFor;
//	double myTime;
//	int source, destination;
//	int occurrence, occurrenceCount = 0;
//
//#pragma region first Problem
//	MPI::Init(argc, argv);
//
//	numOfProcesses = MPI::COMM_WORLD.Get_size();
//	myId = MPI::COMM_WORLD.Get_rank();
//
//	if (myId == 0)
//	{
//		myTime = MPI_Wtime();
//
//		cout << "Please Enter the Number you want to search for.." << endl;
//		cin >> valueToSearchFor;
//
//		cout<< "I did read the value: " << valueToSearchFor << endl;
//
//		// Send the value to 1
//		MPI::COMM_WORLD.Send(&valueToSearchFor,1,MPI::INT,1,0);
//
//		for(int i = 1; i < numOfProcesses; i++)
//		{
//			cout<< "Waiting for Process: " << i << endl;
//			//recieve occurrences
//			MPI::COMM_WORLD.Recv(&occurrence, 1, MPI::INT, i, 10);
//			cout<< "Received(" << i << "): " << occurrence << endl;
//			occurrenceCount += occurrence;
//		}
//
//		cout << endl << "Number of occurrences = " << occurrenceCount << endl;
//
//		myTime = MPI_Wtime() - myTime;
//		cout << "Time is: " << myTime << endl;
//	}
//	else if (myId == 1)
//	{
//	MPI::COMM_WORLD.Recv(&valueToSearchFor,1,MPI::INT,0,0);
//		value = 2;
//
//		//sending the value to childerns
//		destination = myId * 2;
//		cout<< "@1" << endl;
//		if(destination < numOfProcesses)
//			{
//			cout<< "Sending to " << destination << endl;
//			MPI::COMM_WORLD.Send(&valueToSearchFor, 1, MPI::INT, destination, 0);
//			}
//
//		destination ++;
//		if(destination < numOfProcesses)
//		{
//		cout<< "Sending to " << destination << endl;
//			MPI::COMM_WORLD.Send(&valueToSearchFor, 1, MPI::INT, destination, 0);
//		}
//
//		//if same value send 1 to master else send 0
//		if(value == valueToSearchFor)
//			occurrence = 1;
//		else
//			occurrence = 0;
//
//		destination = master;
//		cout<< "Sending to " << destination << endl;
//		MPI::COMM_WORLD.Send(&occurrence, 1, MPI::INT, destination, 10);
//	}
//	else
//	{
//		//recieve the value
//		MPI::COMM_WORLD.Recv(&valueToSearchFor, 1, MPI::INT, MPI::ANY_SOURCE, 0);
//
//		valueToSearchFor = 0;
//		value = myId;
//
//		//sending the value to childerns
//		destination = myId * 2;
//		if(destination < numOfProcesses)
//		{
//			MPI::COMM_WORLD.Send(&valueToSearchFor, 1, MPI::INT, destination, 0);
//		}
//
//		destination = (myId * 2) + 1;
//		if(destination < numOfProcesses)
//		{
//			MPI::COMM_WORLD.Send(&valueToSearchFor, 1, MPI::INT, destination, 0);
//		}
//
//		//if same value send 1 to master else send 0
//		if(value == valueToSearchFor)
//			occurrence = 1;
//		else
//			occurrence = 0;
//
//		destination = master;
//		MPI::COMM_WORLD.Send(&occurrence, 1, MPI::INT, destination, 10);
//	}
//
//	MPI::Finalize();
//#pragma endregion
//}
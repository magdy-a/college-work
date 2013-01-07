/*									»”„ «··Â «·—Õ„‰ «·—ÕÌ„                                                   */

#include <iostream>
#include "UnsortedType.h"
#include "SortedType.h"
#include "StackType.h"
#include "QueType.h"
#include "StackType_Linked.h"
#include "QueType_Linked.h"
#include "UnsortedType_Linked.h"
#include "SortedType_Linked.h"
#include "Binary_Search_Tree.h"
using namespace std;
int Back = 0;

//====================================================================
//====================================================================

void Stack_Type();
void Queue_Type();
void Unsorted_Type();
void Sorted_Type();
void Stack_Type_Linked();
void Queue_Type_Linked();
void Unsorted_Type_Linked();
void Sorted_Type_Linked();
void Binary_Search_Tree();

//====================================================================
//====================================================================

void main()
{
	int number = 15;
	cout<< "\t\t\tBsm Allah Al_Rahman Al_Rahem\n\n\n";
	do
	{
		switch(number)
		{
			case -1:
				return;
			case 1:
				do
				{
					Back = 0;
					cout<<
						"For Unsorted_Array(1)\n"
						"For Unsorted_Linked(2)\n"
						"To Go back(-1)\n\n";
					cout<< "Plz enter a choice : ";
					cin >> number;
					cout<< endl;
					switch(number)
					{
					case -1:
						break;
					case 1:
						Unsorted_Type();
						break;
					case 2:
						Unsorted_Type_Linked();
					}
				}while(number != -1);
				break;
			case 2:
				do
				{
					Back = 0;
					cout<< 
						"For Sorted_Array(1)\n"
						"For Sorted_Linked(2)\n"
						"To Go back(-1)\n\n";
					cout<< "Plz enter a choice : ";
					cin >> number;
					cout<< endl;
					switch(number)
					{
					case -1:
						break;
					case 1:
						Sorted_Type();
						break;
					case 2:
						Sorted_Type_Linked();
					}
				}while(Back == -1);
				break;
			case 3:
				do
				{
					Back = 0;
					cout<< 
						"For Stack_Array(1)\n"
						"For Stack_Linked(2)\n"
						"To Go back(-1)\n\n";
					cout<< "Plz enter a choice : ";
					cin >> number;
					cout<< endl;
					switch(number)
					{
					case -1:
						break;
					case 1:
						Stack_Type();
						break;
					case 2:
						Stack_Type_Linked();
					}
				}while(Back == -1);
				break;
			case 4:
				do
				{
					Back = 0;
					cout<< 
						"For Queue_Array(1)\n"
						"For Queue_Linked(2)\n"
						"To Go back(-1)\n\n";
					cout<< "Plz enter a choice : ";
					cin >> number;
					cout<< endl;
					switch(number)
					{
					case -1:
						break;
					case 1:
						Queue_Type();
						break;
					case 2:
						Queue_Type_Linked();
					}
				}while(Back == -1);
				break;
			case 5:
				Binary_Search_Tree();
		}
		cout<<
			"To Work with UnSortedType(1)\n"
			"To Work with SortedType(2)\n"
			"To Work with StackType(3)\n"
			"To Work with QueueType(4)\n"
			"To Work with TreeType(5)\n"
			"To Exit the program(-1)\n\n";
		cout<< "Plz enter a choice : ";
		cin >> number;
		cout<< endl;
	}while(number != -1);
}


void Stack_Type()
{
	StackType List;
	StackType Temp;
	int number = 0;
	ItemType item;
	Back = 0;
	cout<< 
		"\t\tYou are now using (Stack Array)\n\n"
		"To show all the functions(0)\n"
		"To Make the Stack empty(1)\n"
		"To check if the Stack is full(2)\n"
		"To check if the Stack is empty(3)\n"
		"To Push an element(4)\n"
		"To Pop last element(5)\n"
	    "To show the first element you entered(6)\n"
		"To Print the list(7)\n"
		"To Go Back(-1)\n\n";
	do
	{
		cout<< "\nPlz enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<< 
				"To show all the functions(0)\n"
				"To Make the Stack empty(1)\n"
				"To check if the Stack is full(2)\n"
				"To check if the Stack is empty(3)\n"
				"To Push an element(4)\n"
				"To Pop last element(5)\n"
			    "To show the first element you entered(6)\n"
				"To Print the list(7)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			if(List.IsFull() == true)
				cout<< "The Stack is full ...\n";
			else
				cout<< "The Stack is not full ...\n";
			break;
		case 3:
			if(List.IsEmpty() == true)
				cout<< "The Stack is empty ...\n";
			else
				cout<< "The Stack is not empty ...\n";
			break;
		case 4:
			cout<< "Plz enter a number : ";
			cin >> number;
			item.Initialize(number);
			List.Push(item);
			number = 20;
			break;
		case 5:
			if( ! List.IsEmpty() )
				List.Pop();
			else
				cout<< "The Stack is empty\n";
			break;
		case 6:
			if( ! List.IsEmpty() )
			{
				item = List.Top();
				item.Print();
			}
			else
				cout<< "The Stack is empty ...." << endl;
			break;
		case 7:
			if( ! List.IsEmpty() )
			{
				cout<< "The list will be printed ...\n";
				while( ! List.IsEmpty() )
				{
					item = List.Top();
					item.Print();
					Temp.Push(item);
					List.Pop();
				}
				while( ! Temp.IsEmpty() )
				{
					item = Temp.Top();
					List.Push(item);
					Temp.Pop();
				}
				Temp.MakeEmpty();
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Unsorted_Type()
{
	UnsortedType List;
	ItemType item;
	int number = 0;
	bool found;
	Back = 0;
	cout<< 
		"\t\tYou are now using (Unsorted Array)\n\n"
		"To show out all the functions(0)\n"
		"To make the array empty(1)\n"
		"To see the length of the array(2)\n"
		"To check if the array is full(3)\n"
		"To insert an item(4)\n"
		"To delete an item(5)\n"
		"To Get the next item(6)\n"
		"To reset the array(7)\n"
		"To retrieve an item(8)\n"
		"To Print the list(9)\n"
		"To Go Back(-1)\n\n";
	do
	{
		found = false;
		cout<< "Plz Enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<< 
				"To show out all the functions(0)\n"
				"To make the array empty(1)\n"
				"To see the length of the array(2)\n"
				"To check if the array is full(3)\n"
				"To insert an item(4)\n"
				"To delete an item(5)\n"
				"To Get the next item(6)\n"
				"To reset the array(7)\n"
				"To retrieve an item(8)\n"
				"To Print the list(9)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			cout<< List.LengthIs() << endl;
			break;
		case 3:
			if( List.IsFull() )
				cout<< "This array is full\n";
			else
				cout<< "This array is not full\n";
			break;
		case 4:
			if( ! List.IsFull() )
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				item.Initialize(number);
				if( ! List.RetrieveItem(item) )
					List.InsertItem(item);
				else
					cout<< "This item already exists\n";
				cout<< endl;
			}
			else
				cout<< "Sry the list is full\n";
			number = 20;
			break;
		case 5:
			cout<< "Plz enter a number : ";
			cin >> number;
			item.Initialize(number);
			if(List.RetrieveItem(item))
				List.DeleteItem(item);
			else
				cout<< "Sry this item was not found";
			cout<< endl;
			number = 20;
			break;
		case 6:
			List.GetNextItem(item);
			item.Print();
			break;
		case 7:
			List.ResetList();
			break;
		case 8:
			cout<< "Please enter a number : ";
			cin >> number;
			cout<< endl;
			item.Initialize(number);
			if(List.RetrieveItem(item))
				cout<< "This item was found\n";
			else
				cout<< "This item was not found\n";
			number = 20;
			break;
		case 9:
			if(List.LengthIs() != 0)
			{
				List.ResetList();
				for(int i=0;i<List.LengthIs();i++)
				{
					List.GetNextItem(item);
					item.Print();
				}
				List.ResetList();
				cout<< "\n";
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Sorted_Type()
{
	SortedType List;
	ItemType item;
	int number = 0;
	bool found;
	Back = 0;
	cout<< 
		"\t\tYou are now using (Sorted Array)\n\n"
		"To show out all the functions(0)\n"
		"To make the array empty(1)\n"
		"To see the length of the array(2)\n"
		"To check if the array is full(3)\n"
		"To insert an item(4)\n"
		"To delete an item(5)\n"
		"To Get the next item(6)\n"
	    "To reset the array(7)\n"
		"To retrieve an item(8)\n"
		"To Print the list(9)\n"
		"To Go Back(-1)\n\n";
	do
	{
		found = false;
		cout<< "Plz Enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<< 
				"To show out all the functions(0)\n"
				"To make the array empty(1)\n"
				"To see the length of the array(2)\n"
				"To check if the array is full(3)\n"
				"To insert an item(4)\n"
				"To delete an item(5)\n"
				"To Get the next item(6)\n"
			    "To reset the array(7)\n"
				"To retrieve an item(8)\n"
				"To Print the list(9)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			cout<< List.LengthIs() << endl;
			break;
		case 3:
			if( List.IsFull() )
				cout<< "This array is full\n";
			else
				cout<< "This array is not full\n";
			break;
		case 4:
			cout<< "Plz enter a number : ";
			cin >> number;
			item.Initialize(number);
			List.RetrieveItem(item,found);
			if( ! found )
				List.InsertItem(item);
			else
				cout<< "This item already exists\n";
			cout<< endl;
			number = 20;
			break;
		case 5:
			List.RetrieveItem(item,found);
			if(found)
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				item.Initialize(number);
				List.DeleteItem(item);
				cout<< endl;
			}
			else
				cout<< "Sry this item was not found\n";
			number = 20;
			break;
		case 6:
			if(List.LengthIs() != 0)
			{
				List.GetNextItem(item);
				item.Print();
			}
			else
				cout<< "The list is empty\n";
		case 7:
			List.ResetList();
			break;
		case 8:
			cout<< "Please enter a number : ";
			cin >> number;
			item.Initialize(number);
			List.RetrieveItem(item,found);
			if(found)
				cout<< "The item was found\n";
			else
				cout<< "The item was not found\n";
			number = 20;
			break;
		case 9:
			if(List.LengthIs() != 0)
			{
				List.ResetList();
				for(int i=0;i<List.LengthIs();i++)
				{
					List.GetNextItem(item);
					item.Print();
				}
				List.ResetList();
				cout<< "\n";
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Queue_Type()
{
	QueType List;
	QueType Temp;
	int number = 0;
	ItemType item;
	Back = 0;
	cout<< 
		"\t\t\tYou are using now (Queue Array)\n\n"
		"To show out all the functions(0)\n"
		"To Make the Queue empty(1)\n"
		"To check if the Queue is full(2)\n"
		"To check if the Queue is empty(3)\n"
		"To Enqueue an item(4)\n"
		"To Dequeue first item(5)\n"
		"To Print the list(6)\n"
		"To Go Back(-1)\n\n";
	do
	{
		cout<< "Plz enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<<
				"To show out all the functions(0)\n"
				"To Make the Queue empty(1)\n"
				"To check if the Memory is full(2)\n"
				"To check if the Queue is empty(3)\n"
				"To Enqueue an item(4)\n"
				"To Dequeue first item(5)\n"
				"To Print the list(6)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			if(List.IsFull())
				cout<< "This Queue is full\n";
			else
				cout<< "This Queue is not full\n";
			break;
		case 3:
			if(List.IsEmpty())
				cout<< "This Queue is empty\n";
			else
				cout<< "This Queue is not empty\n";
			break;
		case 4:
			if( ! List.IsFull() )
			{
				cout<< "Please enter a number : ";
				cin >> number;
				cout<< endl;
				item.Initialize(number);
				List.Enqueue(item);
				cout<< endl;
			}
			else
				cout<< "Sry the Queue is full" << endl;
			number = 20;
			break;
		case 5:
			if(! List.IsEmpty())
			{
				List.Dequeue(item);
				cout<< "\nthe item dequeued is :\n";
				item.Print();
			}
			else
				cout<< "Sry This Queue is Empty\n\n";
			break;
		case 6:
			if( ! List.IsEmpty() )
			{
				cout<< "The list will be printed ....\n";
				while( ! List.IsEmpty())
				{
					List.Dequeue(item);
					item.Print();
					Temp.Enqueue(item);
				}
				while( ! Temp.IsEmpty() )
				{
					Temp.Dequeue(item);
					List.Enqueue(item);
				}
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Stack_Type_Linked()
{
	StackType_Linked List;
	StackType_Linked Temp;
	ItemType item;
	int number = 0;
	Back = 0;
	cout<<
		"\t\t\tYou are using now (Stack Linked)\n\n"
		"To Show all the function(0)\n"
		"To Make the stack empty(1)\n"
		"To Check if the memory is full(2)\n"
		"To Check if the Stack is empty(3)\n"
		"To Push an element in the stack(4)\n"
		"To Pop last element(5)\n"
		"To show the first element you entered(6)\n"
		"To Print the list(7)\n"
		"To Go Back(-1)\n\n";
	do
	{
		cout<< "Plz Enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<<
				"To Show all the functions(0)\n"
				"To Make the stack empty(1)\n"
				"To Check if the memory is full(2)\n"
				"To Check if the Stack is empty(3)\n"
				"To Push an element in the stack(4)\n"
				"To Pop last element(5)\n"
				"To show the first element you entered(6)\n"
				"To Print the list(7)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			if(List.IsFull())
				cout<< "The Memory is full\n";
			else
				cout<< "The Memory is not full\n";
			break;
		case 3:
			if(List.IsEmpty())
				cout<< "This stack is empty\n";
			else
				cout<< "This stack is not empty\n";
			break;
		case 4:
			cout<< "Plz enter a number : ";
			cin >> number;
			cout<< endl;
			item.Initialize(number);
			if( ! List.IsFull())
			{
				List.Push(item);
			}
			else
				cout<< "\nSry the memory is full\n";
			number = 20;
			break;
		case 5:
			if( ! List.IsEmpty())
			{
				List.Pop();
			}
			else
				cout<< "\nSry this stack is empty\n";
			break;
		case 6:
			item = List.Top();
			cout<< endl;
			item.Print();
			break;
		case 7:
			if( ! List.IsEmpty() )
			{
				cout<< "The list will be printed ...\n";
				while( ! List.IsEmpty() )
				{
					item = List.Top();
					item.Print();
					Temp.Push(item);
					List.Pop();
				}
				while( ! Temp.IsEmpty() )
				{
					item = Temp.Top();
					List.Push(item);
					Temp.Pop();
				}
				Temp.MakeEmpty();
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Queue_Type_Linked()
{
	int number = 0;
	QueType_Linked List;
	QueType_Linked Temp;
	ItemType item;
	Back = 0;
	cout<<
		"\t\t\tYou are using now (Queue Linked)\n\n"
		"To show all functions(0)\n"
		"To Make the Queue empty(1)\n"
		"To Check if the Memory is full(2)\n"
		"To Check if the Queue is empty(3)\n"
		"To Enqueue an item(4)\n"
		"To Dequeue first item(5)\n"
		"To Print the list(6)\n"
		"To Go Back(-1)\n\n";
	do
	{
		cout<< "Plz enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<<
				"To show all functions(0)\n"
				"To Make the Queue empty(1)\n"
				"To Check if the Memory is full(2)\n"
				"To Check if the Memory is empty(3)\n"
				"To Enqueue an item(4)\n"
				"To Dequeue first item(5)\n"
				"To Print the list(6)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			if(List.IsFull())
				cout<< "The Memory is full\n";
			else
				cout<< "The Memory is not full\n";
			break;
		case 3:
			if(List.IsEmpty())
				cout<< "The Stack is Empty\n";
			else
				cout<< "The Stack is not Empty\n";
			break;
		case 4:
			if(! List.IsFull())
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				cout<< endl;
				item.Initialize(number);
				List.Enqueue(item);
			}
			else
				cout<< "Sry the Memory is full\n";
			number = 20;
			break;
		case 5:
			if(! List.IsEmpty())
			{
				List.Dequeue(item);
				item.Print();
			}
			else
				cout<< "Sry the Queue is empty\n";
			break;
		case 6:
			if( ! List.IsEmpty() )
			{
				cout<< "The list will be printed ....\n";
				while( ! List.IsEmpty())
				{
					List.Dequeue(item);
					item.Print();
					Temp.Enqueue(item);
				}
				while( ! Temp.IsEmpty() )
				{
					Temp.Dequeue(item);
					List.Enqueue(item);
				}
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Unsorted_Type_Linked()
{
	int number = 0;
	UnsortedType_Linked List;
	Back = 0;
	cout<<
		"\t\t\tYou are using now (Unsorted Linked)\n\n"
		"To Show all the functions(0)\n"
		"To Make the list empty(1)\n"
		"To Show the length(2)\n"
		"To Check if the memory is full(3)\n"
		"To Insert an item(4)\n"
		"To Delete an item(5)\n"
		"To Get the next item(6)\n"
		"To Reset the list(7)\n"
		"To Retrieve an item(8)\n"
		"To Print the list(9)\n"
		"To Go Back(-1)\n\n";
	do
	{
		ItemType item;
		bool found = false;
		cout<< "Enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<<
				"To Show all the functions(0)\n"
				"To Make the list empty(1)\n"
				"To Show the length(2)\n"
				"To Check if the memory is full(3)\n"
				"To Insert an item(4)\n"
				"To Delete an item(5)\n"
				"To Get the next item(6)\n"
				"To Reset the list(7)\n"
				"To Retrieve an item(8)\n"
				"To Print the list(9)\n"
				"To Go Back(-1)";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			cout<< "The length is : " << List.LengthIs() << endl;
			break;
		case 3:
			if(List.IsFull())
				cout<< "The memory is full\n";
			else
				cout<< "The memory is not full\n";
			break;
		case 4:
			if( ! List.IsFull())
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				cout<< endl;
				item.Initialize(number);
				List.RetrieveItem(item,found);
				if( ! found )
				{
					List.InsertItem(item);
				}	
				else
					cout<< "This item already exits\n";
			}
			else
				cout<< "The Memory is Full\n";
			number = 20;
			break;
		case 5:
			List.RetrieveItem(item,found);
			if(found)
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				cout<< endl;
				item.Initialize(number);
				List.DeleteItem(item);
			}
			else
				cout<< "No such item was found\n";
			number = 20;
			break;
		case 6:
			if(List.LengthIs() != 0)
			{
				List.GetNextItem(item);
				item.Print();
			}
			else
				cout<< "The list is empty\n";
			break;
		case 7:
			List.ResetList();
			break;
		case 8:
			cout<< "Plz enter a number : ";
			cin >> number;
			cout<< endl;
			item.Initialize(number);
			List.RetrieveItem(item,found);
			if(found)
				cout<< "The item was found\n";
			else
				cout<< "The item was not found\n";
			number = 20;
			break;
		case 9:
			if(List.LengthIs() != 0)
			{
				cout<< "The item will be printed is the order you entered them by .....\n";
				List.PrintList();
			}
			else
				cout<< "The list is empty\n";
			/*if(List.LengthIs() != 0)// el code dah be ye3red el items be tarteb 3aks ele ana da5altoh beh
			{
				List.ResetList();
				for(int i=0;i<List.LengthIs();i++)
				{
					List.GetNextItem(item);
					item.Print();
				}
				List.ResetList();
				cout<< "\n";
			}
			else
				cout<< "The list is empty\n";*/
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Sorted_Type_Linked()
{
	int number = 0;
	SortedType_Linked List;
	Back = 0;
	cout<<
		"\t\t\tYou are using now (Sorted Linked)\n\n"
		"To Show all the functions(0)\n"
		"To Make the list empty(1)\n"
		"To Show the length(2)\n"
		"To Check if the memory is full(3)\n"
		"To Insert an item(4)\n"
		"To Delete an item(5)\n"
		"To Get the next item(6)\n"
		"To Reset the list(7)\n"
		"To Retrieve an item(8)\n"
		"To Print the list(9)\n"
		"To Go Back(-1)\n\n";
	do
	{
		ItemType item;
		bool found = false;
		cout<< "Enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			Back = -1;
			return;
		case 0:
			cout<<
				"To Show all the functions(0)\n"
				"To Make the list empty(1)\n"
				"To Show the length(2)\n"
				"To Check if the memory is full(3)\n"
				"To Insert an item(4)\n"
				"To Delete an item(5)\n"
				"To Get the next item(6)\n"
				"To Reset the list(7)\n"
				"To Retrieve an item(8)\n"
				"To Print the list(9)\n"
				"To Go Back(-1)";
			break;
		case 1:
			List.MakeEmpty();
			break;
		case 2:
			cout<< "The length is ...  " << List.LengthIs() << endl;
			break;
		case 3:
			if(List.IsFull())
				cout<< "The Memory is full\n";
			else
				cout<< "The Memory is not full\n";
			break;
		case 4:
			if( ! List.IsFull() )
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				cout<<endl;
				item.Initialize(number);
				List.RetrieveItem(item,found);
				if( ! found )
				{
					List.InsertItem(item);
				}
				else
					cout<< "The item already exists\n";
			}
			else
				cout<< "The Memory is full\n";
			number = 20;
			break;
		case 5:
			if(List.LengthIs() != 0)
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				cout<< endl;
				item.Initialize(number);
				List.RetrieveItem(item,found);
				if(found)
				{
					List.DeleteItem(item);
				}
				else
					cout<< "This item does not exist\n";
			}
			else
				cout<< "The list is empty\n";
			number = 20;
			break;
		case 6:
			if(List.LengthIs() != 0)
			{
				List.GetNextItem(item);
				item.Print();
			}
			else
				cout<< "The list is empty\n";
			break;
		case 7:
			List.ResetList();
			break;
		case 8:
			cout<< "Plz enter a number : ";
			cin >> number;
			cout<<endl;
			item.Initialize(number);
			List.RetrieveItem(item,found);
			if(found)
				cout<< "The item was found\n";
			else
				cout<< "The item was not found\n";
			number = 20;
			break;
		case 9:
			if(List.LengthIs() != 0)
			{
				List.ResetList();
				for(int i=0;i < (List.LengthIs());i++)
				{
					List.GetNextItem(item);
					item.Print();
				}
				List.ResetList();
				cout<< "\n";
			}
			else
				cout<< "The list is empty\n";
		}
		cout<< "\n\n";
	}while(number != -1);
}
void Binary_Search_Tree()
{
	B_S_T List;
	TreeNode* copy;
	ItemType item;
	bool found = false;
	int number = 0;
	Back = 0;

	/*item.Initialize(1);
	List.InsertItem(item);
	item.Initialize(0);
	List.InsertItem(item);
	item.Initialize(2);
	List.InsertItem(item);
	item.Initialize(5);
	List.InsertItem(item);
	item.Initialize(3);
	List.InsertItem(item);
	item.Initialize(6);
	List.InsertItem(item);
	item.Initialize(4);
	List.InsertItem(item);
	item.Initialize(-1);
	List.InsertItem(item);*/

	cout<<
		"\t\tYou are using (Binary Search Tree)\n\n"
		"To Show all functions(0)\n"
		"To Check if an item is found(1)\n"
		"To Show the number of Nodes(2)\n"
		"To Delete an item(3)\n"
		"To Insert an item(4)\n"
		"To Destroy the tree(5)\n"
		"To Print InOrder(Best Case)(6)\n"
		"To Print PostOrder(7)\n"
		"To Print PreOrder(8)\n"
		"To Copy the tree(9)\n"
		"To Go Back(-1)\n\n";
	do
	{
		cout<< "Plz enter a choice : ";
		cin >> number;
		cout<< endl;
		switch(number)
		{
		case -1:
			return;
		case 0:
			cout<<
				"To Show all functions(0)\n"
				"To Check if an item is found(1)\n"
				"To Show the number of Nodes(2)\n"
				"To Delete an item(3)\n"
				"To Insert an item(4)\n"
				"To Destroy the tree(5)\n"
				"To Print InOrder(Best Case)(6)\n"
				"To Print PostOrder(7)\n"
				"To Print PreOrder(8)\n"
				"To Copy the tree(9)\n"
				"To Go Back(-1)\n\n";
			break;
		case 1:
			if(List.LengthIs() != 0)
			{
				cout << "Plz enter a number : ";
				cin >> number;
				cout<<endl;
				item.Initialize(number);
				List.RetrieveItem(item,found);
				if(found)
					cout<< "The item exists\n";
				else
					cout<< "The item does not exist\n\n";
			}
			else
				cout<< "The list is empty\n\n";
			number = 20;
			break;
		case 2:
			if(List.LengthIs() != 0)
				cout<< "The number of Nodes is .... " << List.LengthIs() << endl;
			else
				cout<< "The List is Empty\n\n";
			break;
		case 3:
			if(List.LengthIs() != 0)
			{
				cout<< "Plz enter a number : ";
				cin >> number;
				cout<< endl;
				item.Initialize(number);
				List.RetrieveItem(item,found);
				if(found)
					List.Control_Delete(item);
				else
					cout<< "This item does not exist\n";
			}
			else
				cout<< "The list is empty\n\n";
			number = 20;
			break;
		case 4:
			cout<< "Plz enter a number : ";
			cin >> number;
			cout<< endl;
			item.Initialize(number);
			List.RetrieveItem(item,found);
			if( ! found )
				List.InsertItem(item);
			else
				cout<< "This item already exists\n\n";
			number = 20;
			break;
		case 5:
			List.Control_Destroy();
			break;
		case 6:
			if(List.LengthIs() != 0)
			{
				cout<< "The list in Inorder .... \n";
				List.Control_PrintTree_InOrder();
			}
			else
				cout<< "The list is empty\n\n";
			break;
		case 7:
			if(List.LengthIs() != 0)
			{
				cout<< "The list in PostOrder .... \n";
				List.Control_PrintTree_PostOrder();
			}
			else
				cout<< "The list is empty\n\n";
			break;
		case 8:
			if(List.LengthIs() != 0)
			{
				cout<< "The list in PreOrder .... \n";
				List.Control_PrintTree_PreOrder();
			}
			else
				cout<< "The list is empty\n\n";
			break;
		case 9:
			if(List.LengthIs() != 0)
			{
				List.Control_Copy(copy);
			}
			else
				cout<< "The list is empty\n\n";
		}
	}while(number != -1);
}
#include <iostream>
#include "Binary_Search_Tree.h"

using namespace std;
int CountNodes(TreeNode* tree);
void Retrieve(TreeNode* tree,ItemType item,bool& found);
void Insert(TreeNode*& tree,ItemType item);
void Delete(TreeNode*& tree);
void GetPredecessor(TreeNode* tree,ItemType& data);
void DeleteItem(TreeNode*& tree,ItemType item);
void Destroy(TreeNode*& tree);
void CopyTree(TreeNode*& copy,TreeNode* originalTree);
void PrintTree_InOrder(TreeNode* tree);
void PrintTree_PostOrder(TreeNode* tree);
void PrintTree_PreOrder(TreeNode* tree);
//======================================================================
//======================================================================
B_S_T::B_S_T()
{
	root = NULL;
}
B_S_T::~B_S_T()
{
	Destroy(root);
}
void B_S_T::InsertItem(ItemType item)
{
	Insert(root,item);
}
void B_S_T::RetrieveItem(ItemType item,bool& found)
{
	Retrieve(root,item,found);
}
int B_S_T::LengthIs()
{
	return CountNodes(root);
}
void B_S_T::Control_PrintTree_InOrder()
{
	PrintTree_InOrder(root);
}
void B_S_T::Control_PrintTree_PostOrder()
{
	PrintTree_PostOrder(root);
}
void B_S_T::Control_PrintTree_PreOrder()
{
	PrintTree_PreOrder(root);
}
void B_S_T::Control_Delete(ItemType item)
{
	DeleteItem(root,item);
}
void B_S_T::Control_Destroy()
{
	Destroy(root);
}
void B_S_T::Control_Copy(TreeNode*& copy)
{
	CopyTree(copy,root);
}
//======================================================================
//======================================================================
int CountNodes(TreeNode* tree)
{
	if(tree == NULL)
		return 0;
	else
		return CountNodes(tree->right) + CountNodes(tree->left) + 1;
}
void Retrieve(TreeNode* tree,ItemType item,bool& found)
{
	if(tree == NULL)
	{
		found = false;
		return;
	}
	switch(item.ComparedTo(tree->info))
	{
		case GREATER:
			Retrieve(tree->right,item,found);
			break;
		case LESS:
			Retrieve(tree->left,item,found);
			break;
		default:
			found = true;
	}
}
void Insert(TreeNode*& tree,ItemType item)
{
	if(tree == NULL)
	{
		tree = new TreeNode;
		tree->left = NULL;
		tree->right = NULL;
		tree->info = item;
	}
	else if(item.ComparedTo(tree->info) == GREATER)
		Insert(tree->right,item);
	else
		Insert(tree->left,item);
}
void Delete(TreeNode*& tree)
{
	ItemType data;
	TreeNode* temp;
	temp = tree;
	if ( tree->left == NULL &&  tree->right == NULL )
	{
		delete tree;
		tree = NULL;
	}
	else if(tree->left == NULL)
	{
		tree = tree->right;
	}
	else if(tree->right == NULL)
	{
		tree = tree->left;
	}
	else
	{
		GetPredecessor(tree->left,data);
		tree->info = data;
		DeleteItem(tree->left,data);
	}
}
void GetPredecessor(TreeNode* tree,ItemType& data)
{
	while(tree->right != NULL)
		tree = tree->right;

	data = tree->info;
}
void DeleteItem(TreeNode*& tree,ItemType item)
{
	if(item.ComparedTo(tree->info) == LESS)
		DeleteItem(tree->left,item);
	else if(item.ComparedTo(tree->info) == GREATER)
		DeleteItem(tree->right,item);
	else
		Delete(tree);
}
void Destroy(TreeNode*& tree)
{
	if(tree != NULL)
	{
		Destroy(tree->left);
		Destroy(tree->right);
		delete tree;
		tree = NULL;
	}
}
void CopyTree(TreeNode*& copy,TreeNode* originalTree)
{
	if(originalTree == NULL)
		copy = NULL;
	else
	{
		copy = new TreeNode;
		copy->info = originalTree->info;
		CopyTree(copy->left,originalTree->left);
		CopyTree(copy->right,originalTree->right);
	}
}
void PrintTree_InOrder(TreeNode* tree)
{
	if(tree != NULL)
	{
		PrintTree_InOrder(tree->left);
		tree->info.Print();
		PrintTree_InOrder(tree->right);
	}
}
void PrintTree_PostOrder(TreeNode* tree)
{
	if(tree != NULL)
	{
		PrintTree_PostOrder(tree->left);
		PrintTree_PostOrder(tree->right);
		tree->info.Print();
	}
}
void PrintTree_PreOrder(TreeNode* tree)
{
	if(tree != NULL)
	{
		tree->info.Print();
		PrintTree_PreOrder(tree->left);
		PrintTree_PreOrder(tree->right);
	}
}
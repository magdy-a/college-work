#ifndef Binary_Search_Tree_h
#define Binary_Search_Tree_h

#include "Binary_Search_Tree_Node.h"

class B_S_T
{
private:
	TreeNode* root;
public:
	B_S_T();
	~B_S_T();
	int LengthIs();
	void RetrieveItem(ItemType item,bool& found);
	void InsertItem(ItemType item);
	void Control_Destroy();
	void Control_Delete(ItemType item);
	void Control_Copy(TreeNode*& copy);
	void Control_PrintTree_InOrder();
	void Control_PrintTree_PostOrder();
	void Control_PrintTree_PreOrder();
};


#endif
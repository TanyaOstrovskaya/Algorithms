#include <iostream>

using namespace std;

// создание очереди на массиве и удаление дупликатов

struct NODE { 
    int Number;
    NODE *Next;
};

NODE * MakeList();
void DeleteDuplicates(NODE*);

int main(){
   NODE *Head = MakeList();
   DeleteDuplicates(Head);
   cout << "Head";
   for(NODE *p=Head->Next; p!=NULL; p=p->Next){
	   cout << " -> " << p->Number;
   }
   return 0;
}

NODE * MakeList() {
  //пример листа
  int Arr[]={2,3,3,3,5,5,8,9,9,9};
  NODE *Head = new NODE, *x;
  Head->Next=NULL;
  Head->Number=-999; 
  int n = sizeof(Arr)/sizeof(int);
  for (int i = 0; i < n; i++) {
	 x = new NODE;
	 x->Number = Arr[i];
	 x->Next = Head->Next;
	 Head->Next = x;
  }
  return Head;
}

void DeleteDuplicates(NODE *Head){
  NODE* temp_head = Head;

  while (temp_head->Next != NULL) {
    if (temp_head->Next->Number == temp_head->Number) {
        temp_head->Next = temp_head->Next->Next;
    } else {
       temp_head = temp_head->Next;
     }   
  }  
}

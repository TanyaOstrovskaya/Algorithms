#include <iostream>
#include <limits.h>

using namespace std;

// адгоритм слияния двух отсортированных листов

struct NODE{
   int Number;
   NODE *Next;
};

NODE * MakeList(int*, int);
NODE *JoinTwoList(NODE*, NODE*);

int main(){
   int Arr1[]={2,3,5,9};
   int Arr2[]={4,6,7,11,16};
   NODE *Head1, *Head2;
   Head1=MakeList(Arr1,sizeof(Arr1)/sizeof(int));
   Head2=MakeList(Arr2,sizeof(Arr2)/sizeof(int));
   NODE *Head = JoinTwoList(Head1, Head2);
   cout << "Head";
   for(NODE* p1=Head->Next; p1!=NULL; p1=p1->Next){
      cout << " -> " << p1->Number;
   }
   return 0;
}


NODE *JoinTwoList(NODE *Head1, NODE *Head2){

   //init result list 
   NODE *HeadToReturn = new NODE, *ResultHead; 
   HeadToReturn->Next = NULL;
   HeadToReturn->Number=INT_MAX;
   ResultHead = HeadToReturn;

   Head1=Head1->Next;
   Head2=Head2->Next;

   while ((Head1 != NULL) && (Head2 != NULL)) {
      ResultHead->Next = new NODE;
      ResultHead = ResultHead->Next;
      if (Head1->Number >= Head2->Number) {         
         ResultHead->Number = Head2->Number;
         ResultHead->Next = NULL;
         Head2 = Head2->Next;
      } else {
         ResultHead->Number = Head1->Number;
         ResultHead->Next = NULL;
         Head1 = Head1->Next;      
      }
   } 

   if (Head2 == NULL) {
      ResultHead->Next = Head1;
      ResultHead = ResultHead->Next;     
   } else {
      ResultHead->Next = Head2;
      ResultHead = ResultHead->Next;  
   }

   return HeadToReturn;
}



NODE * MakeList(int Arr[], int n){

   NODE *Head=new NODE,*x;
   Head->Next=NULL; //Явно указываем на NULL
   Head->Number=INT_MAX; // Условное значение головы
   x=Head;

   for (int i = 0; i < n; i++) {
      x->Next=new NODE;
      x=x->Next;
      x->Number=Arr[i];
      x->Next = NULL;
   }
   return Head;
} 
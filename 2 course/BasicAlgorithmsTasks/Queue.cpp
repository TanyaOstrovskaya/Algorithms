#include <iostream>
#include <limits.h>
 #include <cstdlib>
using namespace std;

const int M=8; 

// простая очередь на массиве 

bool PutInQueue(int);
int TakeFromQueue();
void debugging();
void test();
void printqueue();


struct QUEUE {
   int Q[M]; 	// массив, используемый для хранения очереди
   int F; 		// ИНДЕКС первого элемента очереди
   int L; 		// ИНДЕКС ПОСЛЕДНЕГО
   bool IsEmpty; 
};
QUEUE T;

int main() {
T.F=0;
T.L=-1;
T.IsEmpty=true;
test();     
return 0;
}

bool PutInQueue(int x) {

   //if queue is empty
   if (T.IsEmpty) {
      T.F = 0;
      T.L = 0;
      T.IsEmpty = false;
      T.Q[0] = x;
      return true;
   } else {

      // if queue is full
      if (((T.L - T.F) == M-1) || ((T.L - T.F) == -1))
         return false;

      //situation 1: Last > First
      if (T.F < T.L) {
         if (T.L < M-1) {
            ++T.L;
            T.Q[T.L] = x;
            return true;
         } else {
            T.L = 0;
            T.Q[T.L] = x;
            return true;
         }

      //situation 2 : First > Last
      } else {
         ++T.L; 
         T.Q[T.L] = x;
         return true;
      }
   }
}

//----------------------------------------------
int TakeFromQueue() {

   //if queque is empty
   if (T.IsEmpty) {
      return INT_MAX;
   } else {

      //situation 0 : First == Last
      if (T.F == T.L) {
         int temp = T.Q[T.F];
         T.IsEmpty = true;
         T.F = 0;
         T.L = -1;
         return temp;
      }

      //situation 1 : First < Last
      if (T.F < T.L) {
         ++T.F;         
         return (T.Q[T.F - 1]);
      } else {

      //situation 2 : Last < First
         if (T.F < M-1) {
            ++T.F;            
            return (T.Q[T.F - 1]);
         } else {
            T.F = 0;            
            return (T.Q[M-1]);
         }

      }

   }
}

void printqueue(){
   if (T.IsEmpty) {
      cout << "Queue is empty\n";
      system("pause");
      return;
   }
   cout << "Start: ";
   if(T.F<T.L){
      for (int i = T.F; i != T.L+1; i++) {
         cout << T.Q[i] << " < ";
      }
   } else {
      for (int i = T.F; i != T.L; i++) {
         if (i==M) {
            i=0;
         }
         if (i != T.L)
            cout << T.Q[i] << " < ";
         else
            break;         
      }
      cout << T.Q[T.L] << " < ";
   }
   cout << "End\n";
}

void test(){
   int x;
   for(int i = 0; i < M+1; i++){
      cin >> x;
      if(!PutInQueue(x)) cout << "overflow" << endl;
   }
   printqueue();
   
   for(int i = 0; i < M/2; i++){
      cout << TakeFromQueue() << ", ";
   }
   cout << endl;
   for(int i = 0; i < 1+M/2; i++){
      cin >> x;
      if(!PutInQueue(x)) cout << "overflow" << endl;
   }
   printqueue();
   for(int i = 0; i < M+1; i++){
      cout << TakeFromQueue() << ", ";
   }
} 
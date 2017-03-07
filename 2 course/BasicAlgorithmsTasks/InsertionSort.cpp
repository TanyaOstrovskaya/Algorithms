#include <iostream>
#include <time.h>

using namespace std;

// алгоритм сортировки вставками
void InsertionSort(int*, int);

int main() {
	int N;
	cin >> N;

	int* A = new int[N]; 

	for (int i = 0; i < N; ++i) {
		cin >> A[i];
	}
	InsertionSort(A, N); 

	for (int i = 0; i < N; ++i) {
		cout << A[i] << " "; 
	}

	delete[] A; 
}

void InsertionSort(int* A, int N) {
	for (int i = 0; i < N; i++) {
		int temp = A[i];
		int j = i - 1;
		while (j >= 0 && A[j] > temp) {
			A[j + 1] = A[j];
			j--;
		}
		A[j + 1] = temp;
	}
}
#include <iostream>
#include <time.h>

using namespace std;

// прототипы функций
void merge(int*, int, int);
void mergeRec(int*, int, int);
int N;

int main() {
	cin >> N; 	

	int* A = new int[N];
	for (int i = 0; i < N; i++) {
		//A[i] = rand() % 99 + 1;
		cin >> A[i];
	}

	mergeRec(A, 0, N - 1); // вызов сортировки

	for (int i = 0; i < N; i++) {
		cout << A[i] << " "; // печать
	}
	delete[] A; // освободили память

	return 0;
}

void mergeRec(int* A, int left, int right) {	
	if (left < right) {
		int m = (right + left) / 2;
		mergeRec(A, left, m);
		mergeRec(A, m + 1, right);
		merge(A, left, right);
	}
}

void merge(int *A, int left, int right) {

	int* tempArray = new int[N];
	int m = (right + left) / 2;
 	int i = left, j = m + 1;

	for (int k = left; k <= right; k++)	{
		tempArray[k] = A[k];
	}
	
	int k = left;
	while ((i <= m) && (j <= right)) {
		if (tempArray[i] < tempArray[j]) {
			A[k] = tempArray[i++];
		}
		else {
			A[k] = tempArray[j++];
		}
		++k;
	}

	if (i > m) {
		while (j <= right) {
			A[k++] = tempArray[j++];
		}	
		return;
	}

	if (j > right) {
		while (i <= m) {
			A[k++] = tempArray[i++];
		} 
		return;
	}
};
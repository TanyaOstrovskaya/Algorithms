/*	Алгоритм поиска НОД

	Алгоритм: рекурсивный алгоритм поиска НОД основан на следующей лемме:
если a >= b > 0 и r - остаток от деления a на b, то
НОД (a, b) = НОД (r, b). 

	Оценка времени работы: основывается так же на важной лемме:
если a >= b > 0, то (a mod b) <  a/2. Значит, каждый шаг уменьшает одно из чисел
хотя бы вдвое. Количество шагов - ( log(a) + log(b) ), на каждом шаге выполняется
константное количество операций - деление. => по свойству логарифмов можно сказать, что
T(n) = O (c*( log(a) + log(b) ) = O (log (ab) ) */



#include "stdio.h"

long long LCD(long long a, long long b);


int main() {	
	long long a, b;
	if (scanf("%lli %lli", &a, &b)) {
		printf("%lli", LCD(a, b));
	}	
}

long long LCD(long long a, long long b) {
	
	if (a == b) {
		return a;
	}

	if (a == 0) {
		return b;
	}

	if (b == 0) {
		return a;
	}

	if (a > b) {
		return LCD(a % b, b);
	}
	else {
		return LCD(b % a, a);
	}

}




		
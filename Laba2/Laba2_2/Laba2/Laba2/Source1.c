#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 100000


int compare(const void* x1, const void* x2);
int compare2(const void* x1, const void* x2);
void shell(int* items, int count);
void qs(int* items, int left, int right);
void GenerateArray(int* arr, int size);
void PrintArray(int* arr, int size);

int main(void)
{
	setvbuf(stdin, NULL, _IONBF, 0);
	setvbuf(stdout, NULL, _IONBF, 0);

	clock_t start, end; // объ€вл€ем переменные дл€ определени€ времени выполнени€
	
	int arr[SIZE];

    GenerateArray(arr, SIZE);
    qsort(arr, SIZE / 2, sizeof(int), compare);
    qsort( (arr + 10) , SIZE / 2, sizeof(int), compare2);

	start = clock();
     shell(arr, SIZE);
    end = clock();
    printf("\n Shell algorithm: %.3f \n", difftime(end, start) / CLOCKS_PER_SEC);
    printf("\n \n");

    //GenerateArray(arr, SIZE);
    start = clock();
    qs(arr,0, SIZE - 1);
    end = clock();
    printf("\n Fast Sort algorithm: %.3f \n", difftime(end, start) / CLOCKS_PER_SEC);
    printf("\n \n");

    //GenerateArray(arr, SIZE);
    start = clock();
    qsort(arr, SIZE, sizeof(int), compare);
    end = clock();
    printf("\n qsort function algorithm: %.3f \n", difftime(end, start) / CLOCKS_PER_SEC);
    printf("\n \n");

	getchar();
	return(0);
}

int compare(const void* x1, const void* x2)   // функци€ сравнени€ элементов массива
{
    return (*(int*)x1 - *(int*)x2);              // если результат вычитани€ равен 0, то числа равны, < 0: x1 < x2; > 0: x1 > x2
}

int compare2(const void* x1, const void* x2)   // функци€ сравнени€ элементов массива
{
    return (*(int*)x2 - *(int*)x1);              
}

void shell(int* items, int count)
{
    int i, j, gap, k;
    int x, a[5];

    a[0] = 9; a[1] = 5; a[2] = 3; a[3] = 2; a[4] = 1;

    for (k = 0; k < 5; k++) {
        gap = a[k];
        for (i = gap; i < count; ++i) {
            x = items[i];
            for (j = i - gap; (x < items[j]) && (j >= 0); j = j - gap)
                items[j + gap] = items[j];
            items[j + gap] = x;
        }
    }
}

void qs(int* items, int left, int right) //вызов функции: qs(items, 0, count-1);
{
    int i, j;
    int x, y;

    i = left; j = right;

    /* выбор компаранда */
    x = items[(left + right) / 2];

    do {
        while ((items[i] < x) && (i < right)) i++;
        while ((x < items[j]) && (j > left)) j--;

        if (i <= j) {
            y = items[i];
            items[i] = items[j];
            items[j] = y;
            i++; j--;
        }
    } while (i <= j);

    if (left < j) qs(items, left, j);
    if (i < right) qs(items, i, right);
}

void GenerateArray(int* arr, int size) {
    srand(time(NULL)); // инициализируем параметры генератора случайных чисел
    for (int i = 0; i < size; i++) {
        arr[i] = rand();
    }
}

void PrintArray(int* arr, int size) {
    srand(time(NULL)); // инициализируем параметры генератора случайных чисел
    for (int i = 0; i < size; i++) {
        printf("%d ", arr[i] );
    }
}
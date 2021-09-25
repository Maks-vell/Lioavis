#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 1000

int main(void)
{
	setvbuf(stdin, NULL, _IONBF, 0);
	setvbuf(stdout, NULL, _IONBF, 0);

	clock_t start, end; // объявляем переменные для определения времени выполнения

	int i = 0, j = 0, r;
	int a[SIZE][SIZE], b[SIZE][SIZE], c[SIZE][SIZE], elem_c;

	start = clock();
	srand(time(NULL)); // инициализируем параметры генератора случайных чисел
	while (i < SIZE)
	{
		while (j < SIZE)
		{
			a[i][j] = rand() % 100 + 1; // заполняем массив случайными числами
			j++;
		}
		i++;
	}
	srand(time(NULL)); // инициализируем параметры генератора случайных чисел
	i = 0; j = 0;
	while (i < SIZE)
	{
		while (j < SIZE)
		{
			b[i][j] = rand() % 100 + 1; // заполняем массив случайными числами
			j++;
		}
		i++;
	}

	for (i = 0; i < SIZE; i++)
	{
		for (j = 0; j < SIZE; j++)
		{
			elem_c = 0;
			for (r = 0; r < SIZE; r++)
			{
				elem_c = elem_c + a[i][r] * b[r][j];
				c[i][j] = elem_c;
			}
		}
	}
	end = clock();

	printf("%d", (end - start) / CLOCKS_PER_SEC);
	getchar();

	return(0);
}


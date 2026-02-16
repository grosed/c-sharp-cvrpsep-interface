
#include <stdio.h>

void process_double_array(double* data, int size)
{
    printf("Received array of size %d\n", size);
    for (int i = 0; i < size; i++)
    {
        // Example: modify the array in-place
        data[i] = data[i] * 2.0; 
    }
}

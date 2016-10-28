#include <vector>
#include <iostream>
#include "zad1.h"
using namespace std;
int main() 
{
	int x = 5;
	int y = 6;
	CompQueue queue;
	queue.Enqueue(&x);
	queue.Enqueue(&y);
	
	InhQueue queue2;
	queue2.Enqueue(&x);
	queue2.Enqueue(&y);

	cout << *((int*)queue.Dequeue()) << endl;
	cout << *((int*)queue2.Dequeue()) << endl;
	cin >> x;
	return 0;
}

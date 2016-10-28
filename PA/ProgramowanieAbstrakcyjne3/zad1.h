#pragma once
#include <vector>
using namespace std;

class CompQueue
{
private:
	vector<void*> queue;
public:
	void Enqueue(void* obj)
	{
		queue.push_back(obj);
	}

	void* Dequeue()
	{
		auto obj = queue.at(0);
		queue.erase(queue.begin());
		return obj;
	}
};

class InhQueue : public vector<void*>
{
public:
	void Enqueue(void* obj)
	{
		this->push_back(obj);
	}

	void* Dequeue()
	{
		auto obj = this->at(0);
		this->erase(this->begin());
		return obj;
	}
};
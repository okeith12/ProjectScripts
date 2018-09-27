#include <iostream>
#include <fstream>
#include <utility>
#include <vector>
#include <sys/types.h>
#include <algorithm>
//#include <sys/wait.h>
//#include <unistd.h>
using namespace std;
void swap(int &a, int &b);
pair<int, int> split(vector<pair<int, int>> c, int &a, int &b, bool d);
void childFunction(pair<int, pair<int, int>>b);
void parentFunction(pair<int, pair<int, int>>b);
bool priority_sort( pair<int, int> &a,  pair<int, int> &b);
int main() {
	//pid_t PID;
	int pid = 0;
	int counter = 0;
	bool splitcheck = false;
	int quantum;
	int exec, pr;
	vector<pair<int, int>> a;
	pair<int, pair<int, int>>b;
	vector<pair<int, int>> c;
	fstream input_f;
	input_f.open("input1.txt");
	while (input_f >> quantum) {
		while (input_f >> exec >> pr) {
			a.push_back(make_pair(exec, pr));
		}
	}
	sort(a.begin(), a.end(),priority_sort);
	for (int i = 0; i < a.size(); i++) {
		c.push_back(a[i]);
	}
	cout << "Scheduling queue: ";
	for (int i = 0; i < c.size(); i++) {
		if (c[i].first > quantum) {
			c.insert(c.begin() + i + 2, make_pair(c[i].first - quantum, c[i].second));
			c[i].first = c[i].first - (c[i].first - quantum);
		}
		b = make_pair(pid, c[i]);
		pid++;
		parentFunction(b);
		splitcheck = false;
	}

	
	cout << endl;
	pid = 0;
	int endtime = a.size();
	for (int i = 0; i < a.size(); i++) {
		b = make_pair(pid, a[i]);
		pid++;
	/*	if (PID = fork() == 0) {
			childFunction(b);
			exit(0);
		}
		else
			wait(&endtime);
			*/
	}






	system("pause");

	input_f.close();
}
void childFunction(pair<int, pair<int, int>>b) {
	cout << "Process " << b.first << ": " << "exec time = " << b.second.first << "," << "priorty ="
		<< b.second.second << endl;
	//sleep(b.second.first);
	cout << "Process " << b.first << "ends." << endl;
}
void parentFunction(pair<int, pair<int, int>>b) {
	cout << "(" << b.first << "," << b.second.first << "," <<
		b.second.second << ")" << " ";
}
bool priority_sort( pair<int, int> &a, pair<int, int> &b)
{

	return (a.second < b.second);
}
void swap(int &a, int &b) {
	int temp;
	temp = a;
	a = b;
	b = temp;
}
pair<int, int> split(vector<pair<int, int>> c, int &a, int &b, bool d) {
	if (d == true) {
		b = a - b;
		a = a - b;
	}
	return pair<int, int>(a, b);

}
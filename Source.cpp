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
void childFunction(pair<int, pair<int, int>>b);
void parentFunction(pair<int, pair<int, int>>b);
bool priority_sort(pair<int, int> &a, pair<int, int> &b);
int main() {
	//pid_t PID;
	int pid = 0;
	int count = 0;
	int quantum, exec, pr;
	vector<pair<int, int>> a;
	vector<int> pid2;
	vector<int>::iterator check;
	pair<int, pair<int, int>>b;
	fstream input_f;
	input_f.open("input.txt");
	while (input_f >> quantum) {
		while (input_f >> exec >> pr) {
			a.push_back(make_pair(exec, pr));
		}
	}
	for (int i = 0; i < a.size(); i++) {
		pid2.push_back(pid);
		pid++;
	}
	sort(a.begin(), a.end(), priority_sort);
	cout << "Scheduling queue: ";
	for (int i = 0; i < a.size(); i++) {
		if (a[i].first > quantum) {
			a.insert(a.begin() + i + 2, make_pair(a[i].first - quantum, a[i].second)); //SPLIT IF GREATER THEN QUANTUM;
			pid2.insert(pid2.begin() + i + 2, pid2[i]);
			a[i].first = a[i].first - (a[i].first - quantum);
		}
		b = make_pair(pid2[i], a[i]);
		parentFunction(b);
	}
	cout << endl;
	pid = 0;
	int endtime = a.size();
	for (int i = 0; i < a.size(); i++) {
		b = make_pair(pid2[i], a[i]);
		pid++;
		cout << "Process " << b.first << ": " << "exec time = " << b.second.first << "," << "priorty ="
			<< b.second.second << endl;
		if (pid2[i] == pid2[i+2] !& pid2.end()) {
			//sleep(b.second.first);
		}
		else
		//sleep(b.second.first);
			cout << "Process " << b.first << " ends." << endl;
		/*	if (PID = fork() == 0) {
				childFunction(b);
				exit(0);
			}
			else
				wait(&endtime);
				*/
	}
	input_f.close();
	system("pause");

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
bool priority_sort(pair<int, int> &a, pair<int, int> &b)
{
	return (a.second < b.second);
}

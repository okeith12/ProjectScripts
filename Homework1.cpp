#include <iostream>
#include <fstream>
#include <queue>
#include <string>
#include <utility>
#include <sstream>
#include <vector>
#include <sys/types.h>
#include <unistd.h>

using namespace std;






int main()
{
	int a;
	int b;
	int quan; //Gets the quantum time;
	string line;
	istringstream iss;
	vector<pair<int, int>> s;
	vector<int> temp_arr;
	vector<int> temp_arr1;
	fstream input_f;
	input_f.open("input1.txt");
	while (input_f >> a ) {
		temp_arr.push_back(a);
		while (input_f >> b) {
			temp_arr1.push_back(b);
		}
	
	}
	for (int i = 0; i < temp_arr.size(); i++) {
		cout << temp_arr[i] << " " ;
	}
	cout << endl;
	for (int i = 0; i < temp_arr1.size(); i++) {
		cout << temp_arr1[i] << " ";
		s.push_back(make_pair(temp_arr1[i], temp_arr1[i + 1]));
		i++;
	}
	cout << endl;
	for (int i = 0; i < s.size(); i++) {
		cout << s[i].first << " " << s[i].second << endl;
		
	}
	for (int i = 0; i < s.size(); i++) {
		if (temp_arr[0] < s[i].first)
			cout << "( " << s[i].first - temp_arr[0] << " " << s[i].second << " )" << endl;
	}

	system("pause");
	input_f.close();
}


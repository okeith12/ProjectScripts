#include <iostream>
#include <fstream>
#include <utility>
#include <vector>
#include <sys/types.h>
#include <sys/wait.h>
#include <unistd.h>
using namespace std;
void swap(int &a, int &b);
pair<int,int> split(vector<pair<int,int>> c,int &a, int &b, bool d);
void childFunction(pair<int,pair<int,int>>b);
void parentFunction(pair<int,pair<int,int>>b);
int main(){
    pid_t PID;
    int pid = 0;
    bool splitcheck = false;
    int quantum;
    int exec,pr;
    vector<pair<int,int>> a;
    pair<int,pair<int,int>>b;
    fstream input_f;
  	input_f.open("input1.txt");
    while(input_f >> quantum){
      while(input_f >> exec >> pr ){
        a.push_back(make_pair(exec, pr));
      }
    }

    cout << "Scheduling queue: ";
    for(int i = 0; i < a.size();i++){

      while(a[i].second > a[i+1].second && (a[i] != a.back())){
        swap(a[i],a[i+1]);
      }

      b = make_pair(pid,a[i]);
      parentFunction(b);
      pid++;
  }
    cout << endl;
    pid = 0;
    int endtime = a.size();
    for(int i = 0; i < a.size() ;i++){
      b = make_pair(pid,a[i]);
      pid++;
      if(PID=fork()== 0){
        sleep(b.second.first);
        childFunction(b);
        exit(0);
        }
      else
        wait(&endtime);
    }






    return 0;

    input_f.close();
}
void childFunction(pair<int,pair<int,int>>b){
  cout << "Process " << b.first <<": " <<"exec time = " << b.second.first <<"," <<"priorty ="
  << b.second.second << endl;
}
void parentFunction(pair<int,pair<int,int>>b){
  cout << "("<< b.first <<","<<b.second.first <<","<<
  b.second.second <<")" << " ";
}
void swap(int &a, int &b){
  int temp;
  temp = a;
  a = b;
  b = temp;
}
pair<int,int> split(vector<pair<int,int>> c,int &a, int &b, bool d){
    if(d == true){
      b = a - b;
      a = a - b;
    }
    return pair<int,int>(a,b);

}

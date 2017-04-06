#include <iostream>

using namespace std;

void search(int);

struct NODE {	// Структура "Узел" для элементов дерева

	int elem;	// данные
	NODE *left;		// левое поддерево
	NODE *right;	// правое поддерево
	NODE(int el) { left = right = NULL; elem = el; }
};

NODE *root;	// глобальный корень дерева

void push(int el) { // вставка нового элемента в дерево

	if (!root) {
		root = new NODE(el);
		return;
	}

	NODE *buf;
	buf = root;

	while (true) {
		if (buf->elem >= el) {
			if (!buf->left) {
				buf->left = new NODE(el);
				return;
			}
			buf = buf->left;
		}
		else {
			if (!buf->right) {
				buf->right = new NODE(el);
				return;
			}
			buf = buf->right;
		}
	}
}

bool res = false;
void search_node(int key, NODE* tmp) {
	if (tmp != NULL) {
	if (tmp->elem == key){
		res = true;
		return;
	}
	search_node(key, tmp->left);
	search_node(key, tmp->right);
	} else {
		return;
	}

}

void search(int key) {
	res = false;
	search_node(key, root);
	if (res) cout  <<"Element \""<< key<< "\" is found." ;
	else cout << "Element \"" << key << "\" is not found." ;
}



void print(NODE* cur) {	// печать, симметричный обход
	if (cur->left) {
		print(cur->left);
	}
	cout << cur->elem << endl;
	if (cur->right) {
		print(cur->right);
	}
}

int main() {
	int N;	// кол-во элементов
	cin >> N;
	for (int i = 0; i < N; i++) {	// ввод элементов в дерево
		int a;
		cin >> a;
		push(a);
	}
	cin >> N;	// искомый элемент
	search(N);	// поиск с выводом
	return 0;
}

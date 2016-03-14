function plus (a,b) {
	return a+b;
};

function addCategory(name) {
a = "INSERT INTO category (name) VALUE(";
//name = 'комедии';
b = a+name+');';
return b
}

console.log(addCategory("'Комедия'"));
console.log(addCategory("'Ужасы'"));
console.log(addCategory("'Мелодрамма'"));
console.log(addCategory("'Боевик'"));
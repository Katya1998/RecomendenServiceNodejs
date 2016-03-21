pg = require('pg')
var connectionString = "postgres://postgres:postgres@localhost:5432/market";

var results = [];
var film_list = [
{"title":"Побег из Шоушенка (1994)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_326.jpg"},
{"title":"Зеленая миля (1999)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_435.jpg"},
{"title":"Форрест Гамп (1994)","poster":"http://www.kinopoisk.ru/images/film_big/448.jpg"},
{"title":"Список Шиндлера (1993)","poster":"http://www.kinopoisk.ru/images/film_big/329.jpg"},
{"title":"1+1 (2011)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_535341.jpg"},
{"title":"Начало (2010)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_447301.jpg"},
{"title":"Король Лев (1994)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_2360.jpg"},{"title":"Леон (1994)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_389.jpg"},{"title":"Бойцовский клуб (1999)","poster":"http://www.kinopoisk.ru/images/film_big/361.jpg"},{"title":"Жизнь прекрасна (1997)","poster":"http://www.kinopoisk.ru/images/film_big/381.jpg"},{"title":"Иван Васильевич меняет профессию (1973)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_42664.jpg"},{"title":"Достучаться до небес (1997)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_32898.jpg"},{"title":"Крестный отец (1972)","poster":"http://www.kinopoisk.ru/images/film_big/325.jpg"},{"title":"Интерстеллар (2014)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_258687.jpg"},{"title":"Престиж (2006)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_195334.jpg"},{"title":"Игры разума (2001)","poster":"http://www.kinopoisk.ru/images/film_big/530.jpg"},{"title":"Криминальное чтиво (1994)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_342.jpg"},{"title":"Операция «Ы» и другие приключения Шурика (1965)","poster":"http://www.kinopoisk.ru/images/film_big/42782.jpg"},{"title":"Властелин колец: Возвращение Короля (2003)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_3498.jpg"},{"title":"Гладиатор (2000)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_474.jpg"},{"title":"Назад в будущее (1985)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_476.jpg"},{"title":"Карты, деньги, два ствола (1998)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_522.jpg"},{"title":"Зверополис (2016)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_775276.jpg"},{"title":"Пианист (2002)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_355.jpg"},{"title":"Поймай меня, если сможешь (2002)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_324.jpg"},{"title":"В бой идут одни «старики» (1973)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_25108.jpg"},{"title":"Властелин колец: Братство кольца (2001)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_328.jpg"},{"title":"Отступники (2006)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_81314.jpg"},{"title":"Бриллиантовая рука (1968)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_46225.jpg"},{"title":"Властелин колец: Две крепости (2002)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_312.jpg"},{"title":"Матрица (1999)","poster":"http://www.kinopoisk.ru/images/film_big/301.jpg"},{"title":"Американская история Х (1998)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_382.jpg"},{"title":"Большой куш (2000)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_526.jpg"},{"title":"ВАЛЛ·И (2008)","poster":"http://www.kinopoisk.ru/images/film_big/279102.jpg"},{"title":"Остров проклятых (2009)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_397667.jpg"},{"title":"Пролетая над гнездом кукушки (1975)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_336.jpg"},{"title":"Пробуждение (1990)","poster":"http://www.kinopoisk.ru/images/film_big/2950.jpg"},{"title":"Пираты Карибского моря: Проклятие Черной жемчужины (2003)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_4374.jpg"},{"title":"Хористы (2004)","poster":"http://st.kp.yandex.net/images/film_iphone/iphone360_51481.jpg"},{"title":"Джентльмены удачи (1971)","poster":"http://www.kinopoisk.ru/images/film_big/44386.jpg"}]

//for (var i=0; i<film_list.length; i++){
//var name = film_list[i]['title'];
//var picture = film_list[i]['poster'];
//console.log(film(name, picture));
//}

function film(title, poster){
k = "INSERT INTO category (title, poster) VALUES(";
s = k+title +", " + poster+');';
return s
}



pg.connect(connectionString, function(err, client, done) {
    // Handle connection errors
    if(err) {
      done();
      console.log({ success: false, data: err});
    }
for (var i=0; i<film_list.length; i++){
var name = film_list[i]['title'];
var picture = film_list[i]['poster'];
}
    // SQL Query > Insert Data
    client.query(film(name, picture));
    // SQL Query > Select Data
    var query = client.query("SELECT * FROM film ORDER BY id ASC");
//
//    // Stream results back one row at a time
    query.on('row', function(row) {
        results.push(row);
    });
//
    // After all data is returned, close connection and return results
    query.on('end', function() {
        console.log(results)
        client.close()
    });
})
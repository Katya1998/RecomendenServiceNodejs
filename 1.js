var pg = require('pg'), 
http = require('http'), 
template = require('swig'); 



	var server = new http.Server(), 
	connectionString = "postgres://postgres:postgres@localhost:5432/info"; 

	//рикрепляем к нашей базе 
		server.listen(8000, '127.0.0.1'); 
	//http://localhost:8000/ На этом сервере будет localhost 

		server.on('request', function(req, res){ 
		var tmpl = template.compileFile('./templates/1.html'), //привязка к html 
		film_list = []; //мaссив фильмов 


		pg.connect(connectionString, function(err, client, done) { 
	//условия , база 

		if(err) { 
		done(); 
		console.log({ success: false, data: err}); 
		} 
	//ействия при определенных обстоятльствах 

		var query = client.query("SELECT m.id, m.title, m.poster, m.year, m.rank, COUNT(id) FROM movie AS m JOIN likes AS l ON l.movie_id = m.id GROUP BY (m.id);"); 
		//запрос в базу данных, вытаскивает из movie id, заголовок, рейтинг и привязывает это к таблице лайков. группирует по id с таблицей лайков 
		query.on('row', function(row) { //выводить в одну строчку фильмы 
		film_list.push(row);//пушим в ряд 
		}); 


		query.on('end', function() { //если заканчиваем 
		var row_length = 1; 
		new_results = [] 
		for (var i=0; i<film_list.length; i++){ // Каждый раз по одному, пока i меньше длины массива и выводит все в new results 
		new_results.push(film_list[i]) 
		console.log(new_results); 
		} 
		client.end() 
		return res.end( 
		tmpl( 
		{ 
		'film_list':new_results, 


		'title':'Фильмы' 

		} 
		) 
		) 

		}); 
		}); 
		});
var pg = require('pg')
http = require('http'),
template = require('swig');


var server = new http.Server(),
    connectionString = "postgres://postgres:postgres@localhost:5432/info"

server.listen(8000, '127.0.0.1');

server.on('request', function(req, res){
var tmpl = template.compileFile('./templates/new1.html'),
        film_list = []; 
//var results = []; 
    pg.connect(connectionString, function(err, client, done) {
    // Handle connection errors
       if(err) {
         done();
         console.log({ success: false, data: err});
       }

       var query = client.query("SELECT m.id, m.title, m.poster, m.year, m.rank, COUNT(id) FROM movie AS m JOIN likes AS l ON l.movie_id = m.id GROUP BY (m.id);");//извлекает данные

       query.on('row', function(row) {
         film_list.push(row);
       });

						
        query.on('end', function() {
		
		var row_length = 1;
	    new_results = [];
	    for (var i=0; i<film_list.length; i++){
		new_results.push(film_list[i]);
		}
		console.log(new_results)
		client.end()
        return res.end(//печатает в браузер
		tmpl(
                    {
                        'film_list': new_results,
									  
                        'title': 'Кино для всех'
                    }
                
            )
      	)
       });
    });

});

/*function reshape(film_list){

    var row_length = 4,
        results = [],
        row = [];

    for (var i=0; i<film_list.length; i++){
        row.push(film_list[i])

        if (((i+1) % row_length)==0){
            results.push(row)
            row = []
        }
    }
    console.log(results)
    return results
}
var http = require('http'),
template = require('swig');
pg = require('pg')

var server = new http.Server(),
    connectionString = "postgres://postgres:postgres@localhost:5432/market";

server.listen(8880, '127.0.0.1');

server.on('request', function(req, res){
var tmpl = template.compileFile('./templates/new1.html'),
        film_list = []; 
var results = []; 
    pg.connect(connectionString, function(err, client, done) {
    // Handle connection errors
       if(err) {
         done();
         console.log({ success: false, data: err});
       }

       var query = client.query("SELECT * FROM films ORDER BY id ASC");//извлекает данные

       query.on('row', function(row) {
          results.push(row);
       });

						
        query.on('end', function() {
		
		var row_length = 3;
	    new_results = [];
	    for (var i=0; i<3; i++){
		new_results.push(results[i]);
		}
		console.log(new_results)
		client.end()
        return res.end(//печатает в браузер
		tmpl(
                    {
                        'film_list': [new_results,
									new_results],
                        'title': 'Кино для всех'
                    }
                
            )
      	)
       });
    });


});
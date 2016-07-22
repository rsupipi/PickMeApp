var express = require("express");
var mysql   = require("mysql");
var bodyParser  = require("body-parser");
var md5 = require('MD5');
//var rest = require("./REST.js");
var customer = require("./Customer.js");
var driver = require("./Driver.js");
var vehicle = require("./Vehicle.js");
var booking = require("./Booking.js");



var app  = express();

function REST(){
    var self = this;
    self.connectMysql();
};

REST.prototype.connectMysql = function() {
    var self = this;
    var pool      =    mysql.createPool({
        connectionLimit : 100,
        host     : 'localhost',
        user     : 'root',
        password : 'virtusa',
        database : 'pickme1',
        debug    :  false
    });
    pool.getConnection(function(err,connection){
        if(err) {
          self.stop(err);
        } else {
          self.configureExpress(connection);
        }
    });
}

REST.prototype.configureExpress = function(connection) {
      var self = this;
      app.use(bodyParser.urlencoded({ extended: true }));
      app.use(bodyParser.json());
      var router = express.Router();
      app.use('/pickme', router);
     // var rest_router = new rest(router,connection,md5);
      var customer_router = new customer(router, connection, md5);
      var driver_router = new driver(router, connection, md5);
      var vehicle_router = new vehicle(router, connection, md5);
      var booking_router = new booking(router, connection, md5);
      self.startServer();
}

REST.prototype.startServer = function() {
      app.listen(3000,function(){
          console.log("Server started at Port 3000.");
      });
}

REST.prototype.stop = function(err) {
    console.log("ISSUE WITH MYSQL \n" + err);
    process.exit(1);
}

new REST();

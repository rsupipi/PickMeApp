var mysql = require("mysql");

function REST_ROUTER(router, connection, md5) {
    var self = this;
    self.handleRoutes(router, connection, md5);
}

REST_ROUTER.prototype.handleRoutes = function (router, connection, md5) {
    var self = this;
    
    
    /** get booking */
    
    router.get("/bookingrs/:booking_id", function (req, res) {
        var table = ["customer", "phone", req.params.phone];
        var query = "SELECT * FROM ?? WHERE ??=?";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Customers" : rows });
            }
        });
                
    });
    
    
    
    /** get booking list */
    router.get("/bookings", function (req, res) {
        var table = ["booking"];
        var query = "SELECT * FROM ??";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ table : rows });
            }
        });
         
    });
   
}

module.exports = REST_ROUTER;

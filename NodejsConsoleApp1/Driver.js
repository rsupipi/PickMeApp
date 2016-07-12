var mysql = require("mysql");

function REST_ROUTER(router, connection, md5) {
    var self = this;
    self.handleRoutes(router, connection, md5);
}

REST_ROUTER.prototype.handleRoutes = function (router, connection, md5) {
    var self = this;
    
    /** get driver*/
    
    router.get("/customers/:id", function (req, res) {
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
    
    
    /** get drivers list*/
    router.get("/drivers", function (req, res) {
        var table = ["driver"];
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
    
    /** insert driver */
    router.post("/customers", function (req, res) {
        var query = "INSERT INTO ??(??,??,??,??) VALUES (?,?,?,?)";
        var table = ["customer", "name", "email", "phone", "password", req.body.name , req.body.email, req.body.phone , md5(req.body.password)];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true });
            } else {
                res.json({ "Error" : false });
            }
        });
    });
    
    
    /** customer loging check*/
    router.post("/customers/login", function (req, res) {
        var query = "SELECT * FROM customer where phone = ? and password = ?";
        //var query = "INSERT INTO ??(??,??,??,??) VALUES (?,?,?,?)";
        var table = [req.body.phone , md5(req.body.password)];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : err });
            } else {
                res.json({ "Customers" : rows });
            }
        });
    });
    
    
    /** Edit customer */
    router.put("/customers/password/:phone", function (req, res) {
        var query = "UPDATE ?? SET ?? = ? WHERE ?? = ?";
        var table = ["customer", "password", md5(req.body.password), "phone", req.params.phone];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "Updated the password for email " + req.body.email });
            }
        });
    });
    
    
    /** Delete customer */
    router.delete("/customers/:phone", function (req, res) {
        var query = "DELETE from ?? WHERE ??=?";
        var table = ["customer", "phone", req.params.phone];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "Deleted the user with email " + req.params.phone });
            }
        });
    });

}

module.exports = REST_ROUTER;

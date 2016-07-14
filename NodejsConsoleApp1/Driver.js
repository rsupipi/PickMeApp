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
    router.post("/drivers", function (req, res) {
        var query = "INSERT INTO ??(??,??,??,??,??,??,??,??) VALUES (?,?,?,?,?,?,?,?)";
        var table = ["driver", "NIC", "name", "title", "phoneNo", "Address", "license", "password","email", req.body.NIC, req.body.name, req.body.title, req.body.phoneNo, req.body.Address, req.body.license, md5(req.body.password), req.body.email  ];
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
    router.post("/drivers/login", function (req, res) {
        var query = "SELECT * FROM customer where NIC = ? and password = ?";
        //var query = "INSERT INTO ??(??,??,??,??) VALUES (?,?,?,?)";
        var table = [req.body.NIC , md5(req.body.password)];
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
    router.put("/drivers/password/:NIC", function (req, res) {
        var query = "UPDATE ?? SET ?? = ? WHERE ?? = ?";
        var table = ["driver", "password", md5(req.body.password), "NIC", req.params.phone];
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
    router.delete("/drivers/:NIC", function (req, res) {
        var query = "DELETE from ?? WHERE ??=?";
        var table = ["drivers", "NIC", req.params.phone];
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

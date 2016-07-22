var mysql = require("mysql");

function REST_ROUTER(router, connection, md5) {
    var self = this;
    self.handleRoutes(router, connection, md5);
}

REST_ROUTER.prototype.handleRoutes = function (router, connection, md5) {
    var self = this;
    
    /** get driver detail from database by id */    
    
    /*
    router.get("/drivers/:NIC", function (req, res) {
        var table = ["driver", "NIC", req.params.NIC];
        var query = "SELECT * FROM ?? WHERE ??=?";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "drivers " : rows });
            }
        });
                
    });
     * 
     * */

     
    router.get("/drivers/:NIC", function (req, res) {
        var table = ["driver", "NIC", req.params.NIC];
        var query = "SELECT * FROM ?? WHERE ??=?";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Drivers" : rows });
            }
        });
                
    });
    
    
    
    /** get drivers list from database*/
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
    
    /** insert driver to database */
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
    
    
    /** Driver loging: Check driver's username and password */
    router.post("/drivers/login", function (req, res) {
        var query = "SELECT * FROM driver where NIC = ? and password = ?";
        //var query = "INSERT INTO ??(??,??,??,??) VALUES (?,?,?,?)";
        //var table = [req.body.NIC , md5(req.body.password)];
        var table = [req.body.NIC , md5(req.body.password)];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : err });
            } else {
                res.json({ "drivers" : rows });
            }
        });
    });
    
    
    /** Edit customer from database */
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
    
    
    /** Delete customer from database */
    router.delete("/drivers/:NIC", function (req, res) {
        var query = "DELETE from ?? WHERE ??=?";
        var table = ["driver", "NIC", req.params.NIC];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "Deleted the user with email " + req.params.NIC});
            }
        });
    });

}

module.exports = REST_ROUTER;

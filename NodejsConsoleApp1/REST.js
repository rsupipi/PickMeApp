var mysql = require("mysql");

function REST_ROUTER(router, connection, md5) {
    var self = this;
    self.handleRoutes(router, connection, md5);
}

REST_ROUTER.prototype.handleRoutes = function (router, connection, md5) {
    var self = this;

    router.get("/", function (req, res) {
        res.json({ "Message" : "Welcome to Pick me App!" });
    });
    
    
    
    // ============ getAllTableData =======================
    
    
   
    
    /** get booking list */
    router.get("/bookings", function (req, res) {
        var table = ["booking"];
        getAllTableData(req, res, table);
         
    });
    
    
    /** get data form a mysql table */
    function getAllTableData(req, res, table) {
        var query = "SELECT * FROM ??";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "Success fully method", table : rows });
            }
        });
    }
    
    
    // ============ get Table record =======================
    
   
    // get data form the mysql table
    function getRowData(req, res, table) {
        
        var query = "SELECT * FROM ?? WHERE ??=?";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "Success", "Users" : rows });
            }
        });
    }
    

    //////////////////////////////
   

    
    /*
    router.get("/bookingrs/:booking_id", function (req, res) {
        var table = ["booking", "booking_id", req.params.booking_id];
        var query = "SELECT * FROM ?? WHERE ??=?";
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "Success", "Users" : rows });
            }
        });
         
    });
    
    router.post("/customers", function (req, res) {
        var query = "INSERT INTO ??(??,??,??,??) VALUES (?,?,?,?)";
        var table = ["customer", "name", "email", "phone", "password", req.body.name , req.body.email, req.body.phone , md5(req.body.password)];
        query = mysql.format(query, table);
        connection.query(query, function (err, rows) {
            if (err) {
                res.json({ "Error" : true, "Message" : "Error executing MySQL query" });
            } else {
                res.json({ "Error" : false, "Message" : "User Added !" });
            }
        });
    });
    
    */
    
    

    //////////////////////////////////////////////


    
    
  
    ///////////////////////////////////////////////////////////////////////////////
    /*
    
    router.put("/users",function(req,res){
        var query = "UPDATE ?? SET ?? = ? WHERE ?? = ?";
        var table = ["user_login","user_password",md5(req.body.password),"user_email",req.body.email];
        query = mysql.format(query,table);
        connection.query(query,function(err,rows){
            if(err) {
                res.json({"Error" : true, "Message" : "Error executing MySQL query"});
            } else {
                res.json({"Error" : false, "Message" : "Updated the password for email "+req.body.email});
            }
        });
    });
      */

}

module.exports = REST_ROUTER;

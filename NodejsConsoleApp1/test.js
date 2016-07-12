var User = require('../models/user');

var passport = require('passport');

module.exports.create = function (req, res) {
    var user = new User(req.body);
    user.save(function (err, result) {
        res.json(result);
    });
}

module.exports.list = function (req, res) {
    User.find({}, function (err, results) {
        res.json(results);
    });
}


var mongoose = require('mongoose');
var bcrypt = require('bcryptjs');

var passport = require('passport');

module.exports = mongoose.model('User', {
    fname: String,
    lname: String,
    uname: String,
    password: String
});

// ==================================================================



// ==================================================================




var express = require('express'),
    app = express(),
    bodyParser = require('body-parser'),
    mongoose = require('mongoose'),
    passport = require('passport'),
    expressValidator = require('express-validator');
flash = require('connect-flash');
session = require('express-session');
passport = require('passport');
LocalStrategy = require('passport-local').Strategy;
usersController = require('./server/controllers/users-controller');

mongoose.connect('mongodb://localhost:27017/ride-share');

app.use(bodyParser());

// Register Page
app.get('/register', function (req, res) {
    res.sendfile(__dirname + '/client/views/register.html');
});

// Login Page
app.get('/login', function (req, res) {
    res.sendfile(__dirname + '/client/views/login.html');
});



// =====================================================================

// Passport init
app.use(passport.initialize());
app.use(passport.session());


app.post('/login', 
  passport.authenticate('local', { failureRedirect: '/login', failureFlash: true }),
  function (req, res) {
    res.redirect('/register');
});

passport.serializeUser(function (user, done) {
    done(null, user.id);
});

passport.deserializeUser(function (id, done) {
    findById(id, function (err, user) {
        done(err, user);
    });
});

// ===========================================================================

app.use('/js', express.static(__dirname + '/client/js'));
app.use('/css', express.static(__dirname + '/client/css'));
app.use('/images', express.static(__dirname + '/client/images'));

//REST API
app.get('/api/users', usersController.list);
app.post('/api/users', usersController.create);


app.listen(5000, function () {
    console.log('I\'m Listening...');
})

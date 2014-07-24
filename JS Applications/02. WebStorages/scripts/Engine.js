var Engine = (function () {
    var msgWrapper = document.getElementById('msg-wrapper'),
        msgHolder = document.getElementById('msg-holder'),
        isStarted = false,
        turns,
        number;

    function Engine() {

    }

    function message(msg) {
        console.log(msg);
    }

    function hasDuplicateDigit(numStr) {
        for (var i = 0; i < 4; i += 1) {
            for (var j = i + 1; j < 4; j += 1) {
                if (numStr[i] === numStr[j]) {
                    return true;
                }
            }
        }

        return false;
    }

    function printTurn(pos) {
        var li = document.createElement('li'),
            sheep = document.createElement('img'),
            turn = turns[pos - 1],
            element,
            ram;

        if (pos % 2 === 0) {
            element = 'turns-even';
        } else {
            element = 'turns-odd';
        }

        sheep.src = 'images/sheep.png';
        sheep.width = 25;
        ram = sheep.cloneNode(true);
        ram.src = 'images/ram.png';
        ram.width = 30;
        ram.style.transform = 'rotateY(180deg)';
        li.innerHTML = turn.number + '___';
        for (var i = 0; i < turn.sheeps; i += 1) {
            li.appendChild(sheep.cloneNode(true));
        }

        for (i = 0; i < turn.rams; i += 1) {
            li.appendChild(ram.cloneNode(true));
        }

        document.getElementById(element).appendChild(li);
    }

    function showMessageInput() {
        document.getElementById('hs-user-in').value = '';
        msgWrapper.style.display = 'block';
        msgHolder.style.display = 'block';
    }

    function hideMessageInput() {
        msgWrapper.style.display = 'none';
        msgHolder.style.display = 'none';
    }

    function showHighScore() {
        var storage = JSON.parse(localStorage.getItem('high-score') || '[]'),
            li = document.createElement('li'),
            frag = document.createDocumentFragment();

        li.className = 'label';
        for (var i = 0; i < storage.length; i += 1) {
            li.innerHTML = i + 1 + '. ' + storage[i].name + '..........' + storage[i].score;
            frag.appendChild(li.cloneNode(true));
        }

        document.getElementById('hs').appendChild(frag);
        msgWrapper.style.display = 'block';
        document.getElementById('hs-holder').style.display = 'block';
    }

    function hideHighScore() {
        document.getElementById('hs').innerHTML = '';
        msgWrapper.style.display = 'none';
        document.getElementById('hs-holder').style.display = 'none';
    }

    Engine.prototype.start = function start() {
        this.onNewGameClick();
        isStarted = true;
    };

    Engine.prototype.onGuessClick = function onGuessClick() {
        var userNumber = document.getElementById('user-in').value,
            sheeps = 0,
            rams = 0,
            pos;

        if (!userNumber || !parseInt(userNumber, 10) || userNumber.length !== 4) {
            message('Enter a 4 digits number!');
            return;
        }

        if (+userNumber[0] === 0) {
            message('The first digit can not be 0!');
            return;
        }

        if (hasDuplicateDigit(userNumber)) {
            message('Enter a number with 4 unique digits!');
            return;
        }

        for (var i = 0; i < 4; i += 1) {
            pos = number.indexOf(userNumber[i]);
            if (pos === i) {
                rams++
            } else if (pos > -1) {
                sheeps++;
            }
        }

        printTurn(turns.push({
            number: userNumber,
            sheeps: sheeps,
            rams: rams
        }));

        if (rams === 4) {
            isStarted = false;
            showMessageInput();
        }
    };

    Engine.prototype.saveToHighScore = function saveToHighScore() {
        var len = turns.length,
            name = document.getElementById('hs-user-in').value,
            storage = JSON.parse(localStorage.getItem('high-score') || '[]');

        storage.push({name: name, score: len});
        storage.sort(function (a, b) {
            return a.score - b.score;
        });

        if (len > 10) {
            storage = storage.slice(0, 9);
        }

        localStorage.setItem('high-score', JSON.stringify(storage));
        hideMessageInput();
        showHighScore();
    };

    Engine.prototype.onNewGameClick = function onNewGameClick() {
        turns = [];
        number = new RandomNumber();
        document.getElementById('turns-even').innerHTML = '';
        document.getElementById('turns-odd').innerHTML = '';
        document.getElementById('user-in').value = '';
    };

    Engine.prototype.onHighScoreClick = function onHighScoreClick() {
        showHighScore();
    };

    Engine.prototype.onHighScoreClearClick = function onHighScoreClearClick() {
        localStorage.removeItem('high-score');
        hideHighScore();
    };

    Engine.prototype.onHighScoreExitClick = function onHighScoreExitClick() {
        hideHighScore();
    };

    return Engine;
}());
/* global specialConsole */
(function() {
	specialConsole.writeLine();
	specialConsole.writeLine('This is text!');
	specialConsole.writeLine('This is {1} text in {0} {1}!', 'program', 1);

	specialConsole.writeError();
	specialConsole.writeError('Some error!');
	specialConsole.writeError('Some {1} error in {0} {1}!', 'program', 1);

	specialConsole.writeWarning();
	specialConsole.writeWarning('Something wrong!');
	specialConsole.writeWarning('Something {1} wrong in {0} {1}!', 'program', 1);
}());
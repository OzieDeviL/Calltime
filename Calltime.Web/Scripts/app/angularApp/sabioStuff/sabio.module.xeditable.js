

(function ($sabio) {


    $sabio.moduleOptions.extraModuleDependencies.push("xeditable");
    console.log('hi');

    $sabio.moduleOptions.runners.push(exditableOptionRunner);

    function exditableOptionRunner(editableOptions) {
        editableOptions.theme = 'bs3'; // bootstrap3 theme. Can be also 'bs2', 'default'
    }


}(sabio))


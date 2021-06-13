var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'FldText' },
                { data: 'FldNumInt' },
                { data: 'FldNumDec' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [3], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _crud.init(config);

        //initial html editor
        _ihtml.init($('#eform'), 'CustInput');
    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (fid, elm) {
        _me.edit0.onViewImage('', fid, elm);
    },

}; //class
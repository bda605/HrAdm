var _me = {

    init: function () {        
        //datatable config
        var config = {
            dom: _crud.dtDom,
            columns: [
                { data: 'FldText' },
                { data: 'FldNum' },
                { data: 'FldNum2' },
                { data: '_Fun' },
            ],
            columnDefs: [
                _crud.dtColConfig,
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
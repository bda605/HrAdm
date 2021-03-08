﻿var _me = {

    init: function () {        
        //datatable config
        var config = {
            dom: _crud.dtDom,
            columns: [
                { data: 'UserName' },
                { data: 'AgentName' },
                { data: 'LeaveName' },
                { data: 'StartTime' },
                { data: 'EndTime' },
                { data: 'Hours' },
                { data: 'SignStatusName' },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
                _crud.dtColConfig,
				{ targets: [3], render: function (data, type, full, meta) {
                    return _date.jsToUiDt2(data);
                }},
				{ targets: [4], render: function (data, type, full, meta) {
                    return _date.jsToUiDt2(data);
                }},
				{ targets: [7], render: function (data, type, full, meta) {
                    return _date.jsToUiDt(data);
                }},
				{ targets: [8], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, '請假', true, true, true);
                }},
            ],
        };

        //initial
        _me.edit0 = new EditOne();
        _me.edit0.fnAfterOpenEdit = _me.edit0_afterOpenEdit;
        _crud.init(config, [_me.edit0]);

        //other variables
        _me.divSignRows = $('#divSignRows');
    },

    //TODO: add your code
    //onclick viewFile, called by XiFile component
    onViewFile: function (elm) {
        _me.edit0.onViewImage('', '', elm);
    },

    edit0_afterOpenEdit: function (fun, json) {
        //alert('edit0_afterOpenEdit');
        var box = _me.divSignRows;
        if (fun == _fun.FunC) {
            box.empty();
        } else {
            _ajax.getView('SignRows', { id: _me.edit0.getKey() }, function (html) {
                box.html(html);
            });
        }
    },

}; //class
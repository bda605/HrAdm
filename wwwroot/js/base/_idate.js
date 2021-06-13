﻿//for date input (bootstrap-datepicker)
//_idt drive from _idate
var _idate = $.extend({}, _ibase, {

    //constant
    BoxFilter: '.date',

    //=== get/set start ===
    getO: function (obj) {
        return _date.uiToJsDate(obj.val());
    },

    /**
     * set input value
     * param obj {object} date object
     * param value {string}
     */
    setO: function (obj, value) {
        //obj.val(_date.jsToUiDate(value));
        _idate._boxSetDate(_idate._elmToBox(obj), _date.jsToUiDate(value));
    },

    setEditO: function (obj, status) {
        obj.prop('disabled', !status);
    },

    /**
     * initial, called by _crud.js
     * param box {object}
     * param fid {string} optional
     */ 
    init: function (box, fid) {
        var obj = _str.isEmpty(fid)
            ? box.find(_idate.BoxFilter)
            : _obj.get(fid, box).closet(_idate.BoxFilter);
        if (obj.length == 0)
            return;

        //initial
        obj.datepicker({
            //format: _BR.UiDateFormat,
            language: _fun.locale,
            autoclose: true,
            showOnFocus: false,
            //startDate: '-3d'            
        }).on('changeDate', function (e) {
            //$(_idate).datepicker('hide');
            //傳入 fid, value
            /* temp remark
            if (fnOnChange !== undefined) {
                var me = $(this);
                var fid = !_str.isEmpty(me.attr('id')) ? me.attr('id') : me.data('id');
                fnOnChange(fid, me.val());
            }
            */
        });

        //stop event, or it will popup when reset(jquery 3.21) !!
        obj.find('.input-group-addon').off('click');
    },

    //show/hide datepicker
    onToggle: function (btn) {
        //$(btn).parent().parent().find('input').trigger('focus');
        _idate._elmToBox(btn).datepicker('show');
    },

    //reset value
    onReset: function (btn) {
        //check input status first
        var box = _idate._elmToBox(btn);
        if (_idate.getEditO(_idate._boxGetInput(box)))
            _idate._boxSetDate(box, '');
    },    

    //get edit status, return bool
    getEditO: function (obj) {
        return !obj.is(':disabled');
    },

    //=== private function below ===
    /**
     * element to date box
     * return {object}
     */
    _elmToBox: function (elm) {
        return $(elm).closest(_idate.BoxFilter);
    },

    _boxSetDate: function (box, date) {
        box.datepicker('update', date);
    },

    _boxGetInput: function (box) {
        return box.find('input');
    },

}); //class
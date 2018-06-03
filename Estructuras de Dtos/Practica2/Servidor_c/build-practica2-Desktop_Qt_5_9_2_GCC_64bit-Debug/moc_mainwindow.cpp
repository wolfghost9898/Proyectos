/****************************************************************************
** Meta object code from reading C++ file 'mainwindow.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.9.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../practica2/mainwindow.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'mainwindow.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.9.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_MainWindow_t {
    QByteArrayData data[20];
    char stringdata0[457];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_MainWindow_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_MainWindow_t qt_meta_stringdata_MainWindow = {
    {
QT_MOC_LITERAL(0, 0, 10), // "MainWindow"
QT_MOC_LITERAL(1, 11, 13), // "nuevaConexion"
QT_MOC_LITERAL(2, 25, 0), // ""
QT_MOC_LITERAL(3, 26, 13), // "on_disconnect"
QT_MOC_LITERAL(4, 40, 9), // "readyRead"
QT_MOC_LITERAL(5, 50, 34), // "on_actionCargar_Archivos_trig..."
QT_MOC_LITERAL(6, 85, 21), // "on_pushButton_clicked"
QT_MOC_LITERAL(7, 107, 33), // "on_comboBox_2_currentIndexCha..."
QT_MOC_LITERAL(8, 141, 4), // "arg1"
QT_MOC_LITERAL(9, 146, 29), // "on_actionPost_Orden_triggered"
QT_MOC_LITERAL(10, 176, 28), // "on_actionPre_Orden_triggered"
QT_MOC_LITERAL(11, 205, 27), // "on_actionIn_Orden_triggered"
QT_MOC_LITERAL(12, 233, 27), // "on_actionAmplitud_triggered"
QT_MOC_LITERAL(13, 261, 23), // "on_pushButton_4_clicked"
QT_MOC_LITERAL(14, 285, 25), // "on_subarbolbutton_clicked"
QT_MOC_LITERAL(15, 311, 23), // "on_pushButton_2_clicked"
QT_MOC_LITERAL(16, 335, 23), // "on_pushButton_3_clicked"
QT_MOC_LITERAL(17, 359, 31), // "on_actionCrear_Bloque_triggered"
QT_MOC_LITERAL(18, 391, 36), // "on_actionManual_de_Usuario_tr..."
QT_MOC_LITERAL(19, 428, 28) // "on_actionAcerca_de_triggered"

    },
    "MainWindow\0nuevaConexion\0\0on_disconnect\0"
    "readyRead\0on_actionCargar_Archivos_triggered\0"
    "on_pushButton_clicked\0"
    "on_comboBox_2_currentIndexChanged\0"
    "arg1\0on_actionPost_Orden_triggered\0"
    "on_actionPre_Orden_triggered\0"
    "on_actionIn_Orden_triggered\0"
    "on_actionAmplitud_triggered\0"
    "on_pushButton_4_clicked\0"
    "on_subarbolbutton_clicked\0"
    "on_pushButton_2_clicked\0on_pushButton_3_clicked\0"
    "on_actionCrear_Bloque_triggered\0"
    "on_actionManual_de_Usuario_triggered\0"
    "on_actionAcerca_de_triggered"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_MainWindow[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
      17,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   99,    2, 0x0a /* Public */,
       3,    0,  100,    2, 0x0a /* Public */,
       4,    0,  101,    2, 0x0a /* Public */,
       5,    0,  102,    2, 0x08 /* Private */,
       6,    0,  103,    2, 0x08 /* Private */,
       7,    1,  104,    2, 0x08 /* Private */,
       9,    0,  107,    2, 0x08 /* Private */,
      10,    0,  108,    2, 0x08 /* Private */,
      11,    0,  109,    2, 0x08 /* Private */,
      12,    0,  110,    2, 0x08 /* Private */,
      13,    0,  111,    2, 0x08 /* Private */,
      14,    0,  112,    2, 0x08 /* Private */,
      15,    0,  113,    2, 0x08 /* Private */,
      16,    0,  114,    2, 0x08 /* Private */,
      17,    0,  115,    2, 0x08 /* Private */,
      18,    0,  116,    2, 0x08 /* Private */,
      19,    0,  117,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void, QMetaType::QString,    8,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void MainWindow::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        MainWindow *_t = static_cast<MainWindow *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->nuevaConexion(); break;
        case 1: _t->on_disconnect(); break;
        case 2: _t->readyRead(); break;
        case 3: _t->on_actionCargar_Archivos_triggered(); break;
        case 4: _t->on_pushButton_clicked(); break;
        case 5: _t->on_comboBox_2_currentIndexChanged((*reinterpret_cast< const QString(*)>(_a[1]))); break;
        case 6: _t->on_actionPost_Orden_triggered(); break;
        case 7: _t->on_actionPre_Orden_triggered(); break;
        case 8: _t->on_actionIn_Orden_triggered(); break;
        case 9: _t->on_actionAmplitud_triggered(); break;
        case 10: _t->on_pushButton_4_clicked(); break;
        case 11: _t->on_subarbolbutton_clicked(); break;
        case 12: _t->on_pushButton_2_clicked(); break;
        case 13: _t->on_pushButton_3_clicked(); break;
        case 14: _t->on_actionCrear_Bloque_triggered(); break;
        case 15: _t->on_actionManual_de_Usuario_triggered(); break;
        case 16: _t->on_actionAcerca_de_triggered(); break;
        default: ;
        }
    }
}

const QMetaObject MainWindow::staticMetaObject = {
    { &QMainWindow::staticMetaObject, qt_meta_stringdata_MainWindow.data,
      qt_meta_data_MainWindow,  qt_static_metacall, nullptr, nullptr}
};


const QMetaObject *MainWindow::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *MainWindow::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_MainWindow.stringdata0))
        return static_cast<void*>(this);
    return QMainWindow::qt_metacast(_clname);
}

int MainWindow::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QMainWindow::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 17)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 17;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 17)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 17;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE

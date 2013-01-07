using System;
using System.Windows.Forms;
namespace Files_Project{
    public partial class mainForm : Form{
        public mainForm(){
            InitializeComponent();}
        private void button1_Click(object sender, EventArgs e){
            listView1.Items.Clear();
            switch (cmbRecord.SelectedItem.ToString()){
                case "FixedLength":{
                        switch (cmbField.SelectedItem.ToString()){
                            case "FixedLength":
                                    Record_FixedLength.FixedLengthField('1');
                                    Record_FixedLength.FixedLengthField('2');
                                break;
                            case "Delimiter":
                                    Record_FixedLength.DelimiterField('1');
                                    Record_FixedLength.DelimiterField('2');
                                break;
                            case "LengthIndicator":
                                    Record_FixedLength.LengthIndicatorField('1');
                                    Record_FixedLength.LengthIndicatorField('2');
                                break;
                            case "KeywordValue":
                                    Record_FixedLength.KeywordValueField('1');
                                    Record_FixedLength.KeywordValueField('2');
                                break;}}
                    break;
                case "Delimiter":
                    switch (cmbField.SelectedItem.ToString()){
                        case "FixedLength":
                                Record_Delimiter.FixedLengthField('1');
                                Record_Delimiter.FixedLengthField('2');
                            break;
                        case "Delimiter":
                                Record_Delimiter.DelimiterField('1');
                                Record_Delimiter.DelimiterField('2');
                            break;
                        case "LengthIndicator":
                                Record_Delimiter.LengthIndicatorField('1');
                                Record_Delimiter.LengthIndicatorField('2');
                            break;
                        case "KeywordValue":
                                Record_Delimiter.KeywordValueField('1');
                                Record_Delimiter.KeywordValueField('2');
                            break;}
                    break;
                case "LengthIndicator":
                    switch (cmbField.SelectedItem.ToString()){
                        case "FixedLength":
                                Record_LengthIndicator.FixedLengthField('1');
                                Record_LengthIndicator.FixedLengthField('2');
                            break;
                        case "Delimiter":
                                Record_LengthIndicator.DelimiterField('1');
                                Record_LengthIndicator.DelimiterField('2');
                            break;
                        case "LengthIndicator":
                                Record_LengthIndicator.LengthIndicatorField('1');
                                Record_LengthIndicator.LengthIndicatorField('2');
                            break;
                        case "KeywordValue":
                                Record_LengthIndicator.KeywordValueField('1');
                                Record_LengthIndicator.KeywordValueField('2');
                            break;}
                    break;
                case "Index":
                    switch (cmbField.SelectedItem.ToString()){
                        case "FixedLength":
                                Record_Index.FixedLengthField('1');
                                Record_Index.FixedLengthField('2');
                            break;
                        case "Delimiter":
                                Record_Index.DelimiterField('1');
                                Record_Index.DelimiterField('2');
                            break;
                        case "LengthIndicator":
                                Record_Index.LengthIndicatorField('1');
                                Record_Index.LengthIndicatorField('2');
                            break;
                        case "KeywordValue":
                                Record_Index.KeywordValueField('1');
                                Record_Index.KeywordValueField('2');
                            break;}
                    break;
                case "FixedFields":
                    switch (cmbField.SelectedItem.ToString()){
                        case "FixedLength":
                                Record_FixedFields.FixedLengthField('1');
                                Record_FixedFields.FixedLengthField('2');
                            break;
                        case "Delimiter":
                                Record_FixedFields.DelimiterField('1');
                                Record_FixedFields.DelimiterField('2');
                            break;
                        case "LengthIndicator":
                                Record_FixedFields.LengthIndicatorField('1');
                                Record_FixedFields.LengthIndicatorField('2');
                            break;
                        case "KeywordValue":
                                Record_FixedFields.KeywordValueField('1');
                                Record_FixedFields.KeywordValueField('2');
                            break;}
                    break;}}
        private void Form1_Load(object sender, EventArgs e){
            Program.myForm = this;
            Program.myForm.cmbRecord.SelectedItem = "FixedLength";
            Program.myForm.cmbField.SelectedItem = "FixedLength";}
        private void cmbRecord_SelectedIndexChanged(object sender, EventArgs e){
            readData();}
        private void cmbField_SelectedIndexChanged(object sender, EventArgs e){
            readData();}
        private void readData(){
            if (cmbRecord.SelectedItem != null && cmbField.SelectedItem != null){
                listView1.Items.Clear();
                switch (cmbRecord.SelectedItem.ToString()){
                    case "FixedLength":{
                            switch (cmbField.SelectedItem.ToString()){
                                case "FixedLength":
                                    Record_FixedLength.FixedLengthField('2');
                                    break;
                                case "Delimiter":
                                    Record_FixedLength.DelimiterField('2');
                                    break;
                                case "LengthIndicator":
                                    Record_FixedLength.LengthIndicatorField('2');
                                    break;
                                case "KeywordValue":
                                    Record_FixedLength.KeywordValueField('2');
                                    break;}}
                        break;
                    case "Delimiter":
                        switch (cmbField.SelectedItem.ToString()){
                            case "FixedLength":
                                Record_Delimiter.FixedLengthField('2');
                                break;
                            case "Delimiter":
                                Record_Delimiter.DelimiterField('2');
                                break;
                            case "LengthIndicator":
                                Record_Delimiter.LengthIndicatorField('2');
                                break;
                            case "KeywordValue":
                                Record_Delimiter.KeywordValueField('2');
                                break;}
                        break;
                    case "LengthIndicator":
                        switch (cmbField.SelectedItem.ToString()){
                            case "FixedLength":
                                Record_LengthIndicator.FixedLengthField('2');
                                break;
                            case "Delimiter":
                                Record_LengthIndicator.DelimiterField('2');
                                break;
                            case "LengthIndicator":
                                Record_LengthIndicator.LengthIndicatorField('2');
                                break;
                            case "KeywordValue":
                                Record_LengthIndicator.KeywordValueField('2');
                                break;}
                        break;
                    case "Index":
                        switch (cmbField.SelectedItem.ToString()){
                            case "FixedLength":
                                Record_Index.FixedLengthField('2');
                                break;
                            case "Delimiter":
                                Record_Index.DelimiterField('2');
                                break;
                            case "LengthIndicator":
                                Record_Index.LengthIndicatorField('2');
                                break;
                            case "KeywordValue":
                                Record_Index.KeywordValueField('2');
                                break;}
                        break;
                    case "FixedFields":
                        switch (cmbField.SelectedItem.ToString()){
                            case "FixedLength":
                                Record_FixedFields.FixedLengthField('2');
                                break;
                            case "Delimiter":
                                Record_FixedFields.DelimiterField('2');
                                break;
                            case "LengthIndicator":
                                Record_FixedFields.LengthIndicatorField('2');
                                break;
                            case "KeywordValue":
                                Record_FixedFields.KeywordValueField('2');
                                break;}
                        break;}}}}}
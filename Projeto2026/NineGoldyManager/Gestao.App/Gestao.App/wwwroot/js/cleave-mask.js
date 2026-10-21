function CompanyMaskInit() {
    console.log("Carregando mascaras - Company....");

    LoadCNPJMask();
    LoadCEPMask();    
}

function CustomerMaskInit(){
    console.log("Carregando mascaras - Customer....");

    LoadCPFMask();
    LoadCNPJMask();
    LoadCEPMask();
    LoadPhoneMask();
    LoadCellphoneMask();
}

const LoadCNPJMask = () => {
    var cleaveCNPJ;

    var cnpjMask = {
        delimiters: [".", ".", "/", "-"],
        blocks: [2, 3, 3, 4, 2],
        uppercase: !0
    }

    document.querySelector("#cnpj") && (cleaveCNPJ = new Cleave("#cnpj", cnpjMask));
}

const LoadCPFMask = () => {
    var cleaveCNPJ;

    var cnpjMask = {
        delimiters: [".", ".", "-"],
        blocks: [3, 3, 3, 2],
        uppercase: !0
    }

    document.querySelector("#cpf") && (cleaveCNPJ = new Cleave("#cpf", cnpjMask));
}

const LoadCEPMask = () => {

    var cleaveCEP;

    var cepMask = {
        delimiters: [".", "-"],
        blocks: [2, 3, 3],
        uppercase: !0
    }

    document.querySelector("#cep") && (cleaveCEP = new Cleave("#cep", cepMask));
}

const LoadPhoneMask = () => {
    var cleavePhone;

    var phoneMask = {
        delimiters: ["(",")","-"],
        blocks: [0,2, 4, 4],
        uppercase: !0
    }

    document.querySelector("#phone") && (cleavePhone = new Cleave("#phone", phoneMask));
}

const LoadCellphoneMask = () => {
    var cleavePhone;

    var cellphoneMask = {
        delimiters: ["(",")","-"],
        blocks: [0, 2, 5, 4],
        uppercase: !0
    }

    document.querySelector("#cellphone") && (cleavePhone = new Cleave("#cellphone", cellphoneMask));
}
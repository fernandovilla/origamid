<template>
    <div>
        <input type="text" v-model="searchQuery" placeholder="Filtrar itens..." />
        <label>
            <select v-model="filterOption">
                <option value="todos">Todos</option>
                <option value="0">Par</option>
                <option value="1">Ímpar</option>
            </select>
        </label>
        <p>
            <select v-model="filterOptionStatus">
                <option value="todos">Todos</option>
                <option value="0">Inativo</option>
                <option value="1">Ativo</option>
            </select>
        </p>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Link</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, index) in filteredItems" :key="index">
                    <td>{{ item.id }}</td>
                    <td>{{ item.nome }}</td>
                    <td>{{ item.link }}</td>
                    <td>{{ item.status }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    data() {
        return {
            searchQuery: '',
            filterOption: 'todos',
            filterOptionStatus: 'todos',
            itens: [
                { id: 1, nome: 'Home', link: '/', status: '1' },
                { id: 2, nome: 'Ingredientes', link: '/ingredientes', status: '0' },
                { id: 3, nome: 'Receitas', link: '/receitas', status: '1' },
                { id: 4, nome: 'Unidades de Medida', link: '/unidades-medida', status: '1' },
                { id: 5, nome: 'Categorias', link: '/categorias', status: '1' },
                { id: 6, nome: 'Usuários', link: '/usuarios', status: '0' },
                { id: 7, nome: 'Configurações', link: '/configuracoes', status: '0' }
            ]
        };
    },
    computed: {
        filteredItems() {
            return this.itens.filter(item => {
                const matchesQuery = item.nome.toLowerCase().includes(this.searchQuery.toLowerCase());
                const matchesFilter = this.filterOption === 'todos' || (this.filterOption === '0' && item.id % 2 === 0) || (this.filterOption === '1' && item.id % 2 !== 0);
                const matchesFilterStatus = this.filterOptionStatus === 'todos' || item.status === this.filterOptionStatus;
                return matchesQuery && matchesFilter && matchesFilterStatus && matchesFilterStatus
            });
        }
    },
    methods: {
        toggleMenu() {
            this.isOpen = !this.isOpen;
        }
    }
};
</script>

<style scoped>
input[type="text"] {
    margin-bottom: 10px;
    padding: 5px;
    width: 100%;
    box-sizing: border-box;
}

select {
    margin-bottom: 10px;
    padding: 5px;
    width: 100%;
    box-sizing: border-box;
}

table {
    width: 100%;
    border-collapse: collapse;
}

th, td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: left;
}

th {
    background-color: #f2f2f2;
}
</style>
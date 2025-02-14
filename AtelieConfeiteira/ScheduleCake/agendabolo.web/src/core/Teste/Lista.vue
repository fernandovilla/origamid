<template>
    <div>
        <input type="text" v-model="searchQuery" placeholder="Filtrar itens..." />
        <label>
            <select v-model="filterOption">
                <option value="todos">Todos</option>
                <option value="par">Par</option>
                <option value="impar">Ímpar</option>
            </select>
        </label>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Link</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in filteredItems" :key="item.id">
                    <td>{{ item.id }}</td>
                    <td>{{ item.nome }}</td>
                    <td>{{ item.link }}</td>
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
            itens: [
                { id: 1, nome: 'Home', link: '/' },
                { id: 2, nome: 'Ingredientes', link: '/ingredientes' },
                { id: 3, nome: 'Receitas', link: '/receitas' },
                { id: 4, nome: 'Unidades de Medida', link: '/unidades-medida' },
                { id: 5, nome: 'Categorias', link: '/categorias' },
                { id: 6, nome: 'Usuários', link: '/usuarios' },
                { id: 7, nome: 'Configurações', link: '/configuracoes' }
            ]
        };
    },
    computed: {
        filteredItems() {
            return this.itens.filter(item => {
                const matchesQuery = item.nome.toLowerCase().includes(this.searchQuery.toLowerCase());
                const matchesFilter = this.filterOption === 'todos' ||
                                      (this.filterOption === 'par' && item.id % 2 === 0) ||
                                      (this.filterOption === 'impar' && item.id % 2 !== 0);
                return matchesQuery && matchesFilter;
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
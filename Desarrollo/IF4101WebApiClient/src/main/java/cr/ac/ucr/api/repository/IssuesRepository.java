package cr.ac.ucr.api.repository;


import cr.ac.ucr.api.model.Issue;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface IssuesRepository extends JpaRepository<Issue, Integer> {
    @Query(value = "{ call listIssue(:email)}", nativeQuery = true)
    List<Issue> listIssue(@Param("email") String email);
}
